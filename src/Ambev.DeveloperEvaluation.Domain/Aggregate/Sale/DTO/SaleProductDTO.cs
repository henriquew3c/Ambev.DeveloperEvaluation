namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.DTO
{
    public class SaleProductDTO
    {
        /// <summary>
        /// Gets the sale item's product id.
        /// </summary>
        public string ProductId { get; set; } = "";

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
