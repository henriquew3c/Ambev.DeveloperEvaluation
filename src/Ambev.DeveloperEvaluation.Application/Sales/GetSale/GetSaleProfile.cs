using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Profile for mapping between User entity and GetSaleResponse
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>();
    }
}
