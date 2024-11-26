using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory;
using FluentValidation;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public static class CreateSaleAdapter
    {
        public static Sale Map(this CreateSaleCommand request)
        {
            if (!request.BranchId.ValidGuid())
            {
                throw new ValidationException(
                    new List<ValidationFailure> { new ValidationFailure(request.BranchId, $"Branch id is not valid.") }
                );
            }

            if (!request.CustomerId.ValidGuid())
            {
                throw new ValidationException(
                    new List<ValidationFailure> { new ValidationFailure(request.CustomerId, $"Customer id is not valid.") }
                );
            }

            return SaleFactory.GetSaleForCreate(request.CustomerId, request.BranchId, request.Date);
        }
    }
}



