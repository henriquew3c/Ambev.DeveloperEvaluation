namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Represents a request to delete a sale in the system.
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale to delete.
    /// </summary>
    public Guid Id { get; set; }
}