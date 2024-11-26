using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Profile for mapping between Application and API CreateSale responses
    /// </summary>
    public class DeleteSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale feature
        /// </summary>
        public DeleteSaleProfile()
        {
            CreateMap<Guid, Application.Sales.DeleteSale.DeleteSaleCommand>()
                .ConstructUsing(id => new Application.Sales.DeleteSale.DeleteSaleCommand(id));
        }
    }
}



