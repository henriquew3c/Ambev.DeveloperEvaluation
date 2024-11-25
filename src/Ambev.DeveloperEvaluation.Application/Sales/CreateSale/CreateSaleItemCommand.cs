namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a sale item.
/// </summary>
public class CreateSaleItemCommand
{
    /// <summary>
    /// Gets or sets the product id.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity { get; set; }
}