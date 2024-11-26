using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.DTO;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    /// <summary>
    /// Gets or sets the sale id.
    /// </summary>
    public string SaleId { get; set; } 
    
    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public string CustomerId { get; set; } 
    
    /// <summary>
    /// Gets or sets the branch id.
    /// </summary>
    public string BranchId { get; set; }

    /// <summary>
    /// Gets or sets the sale date.
    /// </summary>
    public DateTime? UpdateAt { get; set; }

    /// <summary>
    /// Gets or sets the sale status.
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the list of sale items.
    /// </summary>
    public List<SaleProductDTO> Products { get; set; }
}