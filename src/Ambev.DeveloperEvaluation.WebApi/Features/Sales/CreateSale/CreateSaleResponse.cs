namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation.
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public Guid? UserId { get; set; } = null;

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime? Date { get; set; } = null;

        /// <summary>
        /// The list of sale items.
        /// </summary>
        public List<CreateSaleProductResponse> Products { get; set; } = new();
    }
}
