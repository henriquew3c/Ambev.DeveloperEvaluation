using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Handler for processing GetAllSalesCommand requests.
/// </summary>
public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, PaginatedList<GetAllSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetAllSalesHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetAllSalesCommand request.
    /// </summary>
    /// <param name="command">The GetAllSales command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A paginated list of sales.</returns>
    public async Task<PaginatedList<GetAllSalesResult>> Handle(GetAllSalesCommand command, CancellationToken cancellationToken)
    {
        var paginatedSales = await _saleRepository.GetPagedSalesAsync(command.PageNumber, command.PageSize, cancellationToken);
        var mappedSales = _mapper.Map<List<GetAllSalesResult>>(paginatedSales);

        return new PaginatedList<GetAllSalesResult>(mappedSales, paginatedSales.TotalCount, command.PageNumber, command.PageSize);
    }
}