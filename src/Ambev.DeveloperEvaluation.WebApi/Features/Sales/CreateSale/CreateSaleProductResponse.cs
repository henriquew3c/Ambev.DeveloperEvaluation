namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProductResponse
{
    /// <summary>
    /// Gets the sale item's product id.
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// The quantity.
    /// </summary>
    public int Quantity { get; set; }
}