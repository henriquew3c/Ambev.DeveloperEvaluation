using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory
{
    public static class SaleFactory
    {
        public static Aggregate.Sale.Sale GetSaleForCreate(string customerId, string branchId, DateTime? createAt)
        {
            var sale = new Aggregate.Sale.Sale(customerId, branchId, createAt);
            sale.Validate(sale, new CreateSaleValidator());
            return sale;
        }
        
        public static Aggregate.Sale.Sale GetSaleForUpdate(string customerId, string branchId, DateTime? updateAt)
        {
            var sale = new Aggregate.Sale.Sale(customerId, branchId, null, updateAt);
            sale.Validate(sale, new UpdateSaleValidator());
            return sale;
        }
    }
}
