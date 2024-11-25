using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetSaleResponse
{ 
    /// <summary>
    /// The unique identifier of the created sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public Guid? CustomerId { get; set; } = null;

    /// <summary>
    /// Gets or sets the branch id.
    /// </summary>
    public Guid? BranchId { get; set; } = null;

    /// <summary>
    /// Gets or sets the sale date.
    /// </summary>
    public DateTime? CreateAt { get; set; } = null;

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
