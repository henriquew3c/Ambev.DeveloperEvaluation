using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory
{
    public static class SaleFactory
    {
        public static Aggregate.Sale.Sale Create(string customerId, DateTime date, string branchId)
        {
            var sale = new Aggregate.Sale.Sale(customerId, date, branchId);
            sale.Validate(sale, new SaleValidator());
            return sale;
        }
    }
}
