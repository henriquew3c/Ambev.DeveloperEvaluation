using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
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
}