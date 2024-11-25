namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Repository;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a product int the repository
    /// </summary>
    /// <param name="itemProductId">The product to get</param>
    /// <returns>The product or null</returns>
    Product? GetProductById(Guid itemProductId);
}