using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between User entity and CreateSaleResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<Sale, CreateSaleResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<SaleProduct, CreateSaleItemResult>();
    }
}
