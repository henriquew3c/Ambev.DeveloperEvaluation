using Ambev.DeveloperEvaluation.Common.Pagination;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Command for retrieving all sales with pagination.
/// </summary>
public class GetAllSalesCommand : IRequest<PaginatedList<GetAllSalesResult>>
{
    /// <summary>
    /// Number of the page to retrieve.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; set; } = 10;
}