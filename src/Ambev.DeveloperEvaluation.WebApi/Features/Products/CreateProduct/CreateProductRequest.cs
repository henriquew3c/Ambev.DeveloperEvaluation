namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequest
{
    /// <summary>
    /// Gets the product's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the product's price.
    /// </summary>
    public decimal Price { get; set; }
}