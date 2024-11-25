namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created product,
/// and details about the product, such as product number, date, customer, branch,
/// total amount, items, and cancellation status.
/// </remarks>
public class CreateProductResult
{
    /// <summary>
    /// The unique identifier of the created product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the product's name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the product's price.
    /// </summary>
    public decimal Price { get; private set; }


}