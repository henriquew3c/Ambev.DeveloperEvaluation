using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
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
    /// Gets the sale's total.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets the sale's discount.
    /// </summary>
    public decimal DiscountAmount { get; private set; }

    /// <summary>
    /// Gets the sale's discount percent.
    /// </summary>
    public decimal DiscountPercent { get; private set; }
}
