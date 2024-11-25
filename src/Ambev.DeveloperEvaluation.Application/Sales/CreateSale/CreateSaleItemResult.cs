namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response model for a sale item.
/// </summary>
public class CreateSaleItemResult
{
    /// <summary>
    /// Gets or sets the product id.
    /// </summary>
    /// <value>The id of the product.</value>
    public string ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    /// <value>The quantity of the product.</value>
    public int Quantity { get; set; }
}