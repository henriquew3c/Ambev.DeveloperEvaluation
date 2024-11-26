namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// API response model for DeleteSale operation.
/// </summary>
public class DeleteSaleResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether the sale was deleted successfully.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the delete operation.
    /// </summary>
    public string Message { get; set; } = string.Empty;
}