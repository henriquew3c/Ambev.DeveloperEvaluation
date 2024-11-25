
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{

    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        public List<CreateSaleProductRequest> Products { get; set; }
    }
}
