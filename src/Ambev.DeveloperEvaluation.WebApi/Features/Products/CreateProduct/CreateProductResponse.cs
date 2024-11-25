namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductResponse
{
    /// <summary>
    /// Gets the sale item's product id.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the product's name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the product's price.
    /// </summary>
    public decimal Price { get; private set; }
}