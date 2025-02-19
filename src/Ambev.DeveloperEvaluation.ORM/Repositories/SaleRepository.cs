using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Events;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Channels;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;
    private readonly IModel _channel;
    private readonly ILogger<SaleRepository> _logger;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    /// <param name="channel">The RabbitMQ channel</param>
    /// <param name="logger">The logger instance</param>
    public SaleRepository(DefaultContext context, IModel channel, ILogger<SaleRepository> logger)
    {
        _context = context;
        _channel = channel;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Update a sale in the database
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale</returns>
    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Creates a new sale product in the database
    /// </summary>
    /// <param name="product">The sale product to create</param>
    public async Task AddSaleProductAsync(SaleProduct product)
    {
        if (_context.ChangeTracker.Entries<SaleProduct>().Any(i => i.Entity.Id == product.Id))
        {
            return;
        }

        await _context.SaleProducts.AddAsync(product);
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (sale == null) return null;

        await _context.Entry(sale)
            .Collection(i => i.Products).LoadAsync(cancellationToken);

        return sale;
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetActiveSaleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await _context.Sales
            .Where(o => o.Id == id)
            .Where(o => o.Status != SaleStatus.Cancelled)
            .Where(o => o.Status != SaleStatus.Finish)
            .Where(o => o.Status != SaleStatus.Deleted)
            .FirstOrDefaultAsync(cancellationToken);

        if (sale == null) return null;

        await _context.Entry(sale)
            .Collection(i => i.Products).LoadAsync(cancellationToken);

        return sale;
    }

    /// <summary>
    /// Retrieves a paginated list of sales from the database.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A paginated list of sales.</returns>
    public async Task<PaginatedList<Sale>> GetPagedSalesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = _context.Sales.AsNoTracking().Include(s => s.Products);
        return await PaginatedList<Sale>.CreateAsync(query, pageNumber, pageSize);
    }

    public void PublishSaleRegisteredEvent(SaleRegisteredEventMessage message)
    {
        try
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: "",
                routingKey: "sale_registered_queue",
                basicProperties: null,
                body: body); 
            
            Console.WriteLine($" [x] Sent {message}");

            _logger.LogInformation("SaleRegisteredEventMessage published successfully: {SaleId}", message.SaleId);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error publishing SaleRegisteredEventMessage: {SaleId}", message.SaleId);
            // Todo: Aqui você pode adicionar lógica adicional, como tentar novamente ou notificar um sistema de monitoramento
        }
    }
}