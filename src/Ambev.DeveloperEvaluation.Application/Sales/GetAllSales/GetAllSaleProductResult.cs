using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Represents the result of a product item for the GetAllSales operation.
    /// </summary>
    public class GetAllSaleProductResult
    {
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The id of the product.</value>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        /// <value>The quantity of the product.</value>
        public int Quantity { get; set; }
    }
}
