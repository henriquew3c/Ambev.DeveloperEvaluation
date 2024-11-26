namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSaleProductResponse
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