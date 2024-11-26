using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    /// <summary>
    /// Profile for AutoMapper configuration for sales related mappings.
    /// </summary>
    public class GetAllSalesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesProfile"/> class.
        /// </summary>
        public GetAllSalesProfile()
        {
            CreateMap<Sale, GetAllSalesResult>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<SaleProduct, GetAllSaleProductResult>();

            CreateMap<Sale, GetAllSalesResponse>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<SaleProduct, GetAllSaleProductResponse>();

            
            CreateMap<GetAllSalesResult, GetAllSalesResponse>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<GetAllSaleProductResult , GetAllSaleProductResponse>();
        }
    }
}
