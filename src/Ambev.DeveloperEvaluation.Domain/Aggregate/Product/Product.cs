using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Product
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets the product's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the product's price.
        /// </summary>
        public decimal Price { get; private set; }

        public List<SaleProduct> SaleIterItems { get; private set; }

        public Product()
        {

        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
