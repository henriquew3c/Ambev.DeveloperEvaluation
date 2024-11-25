using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory
{
    public static class SaleFactory
    {
        public static Aggregate.Sale.Sale Create(string userId, DateTime date)
        {
            var sale = new Aggregate.Sale.Sale(userId, date);
            sale.Validate(sale, new SaleValidator());
            return sale;
        }
    }
}
