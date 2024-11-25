using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.DTO;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

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
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the sale date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the list of sale items.
    /// </summary>
    public List<SaleProductDTO> Products { get; set; }
}