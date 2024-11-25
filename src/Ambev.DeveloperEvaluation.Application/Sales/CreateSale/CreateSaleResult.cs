using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created sale,
/// and details about the sale, such as sale number, date, customer, branch,
/// total amount, items, and cancellation status.
/// </remarks>
public class CreateSaleResult
{
    /// <summary>
    /// The unique identifier of the created sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public Guid? UserId { get; set; } = null;

    /// <summary>
    /// Gets or sets the sale date.
    /// </summary>
    public DateTime? Date { get; set; } = null;

    /// <summary>
    /// The list of sale items.
    /// </summary>
    public List<CreateSaleItemResult> Products { get; set; } = new();
}