using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.DTO;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping between Application and API CreateSale responses
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale feature
        /// </summary>
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleRequest, CreateSaleCommand>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<CreateSaleResult, CreateSaleResponse>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<CreateSaleProductRequest, SaleProductDTO>();

            CreateMap<CreateSaleItemResult, CreateSaleProductResponse>();
        }
    }
}



