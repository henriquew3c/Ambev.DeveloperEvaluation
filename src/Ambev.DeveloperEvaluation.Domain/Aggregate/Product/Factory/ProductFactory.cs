using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Validations;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Factory
{
    public static class ProductFactory
    {
        public static Aggregate.Product.Product Create(string name, decimal price)
        {
            var sale = new Aggregate.Product.Product(name, price);
            sale.Validate(sale, new ProductValidator());
            return sale;
        }
    }
}
