using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Repository;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of Iproduct using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new product in the database
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public Product? GetProductById(Guid itemProductId)
    {
        return _context.Products.FirstOrDefault(p => p.Id == itemProductId);
    }
}