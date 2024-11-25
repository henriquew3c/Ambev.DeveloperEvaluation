namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProductRequest
{
    /// <summary>
    /// Gets the sale item's product id.
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    public int Quantity { get; set; }
}