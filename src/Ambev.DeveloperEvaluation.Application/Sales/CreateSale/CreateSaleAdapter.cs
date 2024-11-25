using Ambev.DeveloperEvaluation.Common.Exception;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public static class CreateSaleAdapter
    {
        public static Sale Map(this CreateSaleCommand request)
        {
            return SaleFactory.Create(request.UserId, request.Date);
        }
    }
}



