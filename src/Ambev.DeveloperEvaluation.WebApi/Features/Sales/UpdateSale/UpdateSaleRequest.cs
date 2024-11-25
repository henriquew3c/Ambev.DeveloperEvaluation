
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{

    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class UpdateSaleRequest
    {
        /// <summary>
        /// Gets or sets the sale id.
        /// </summary>
        public string SaleId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public string CustomerId { get; set; }
        
        /// <summary>
        /// Gets or sets the branch id.
        /// </summary>
        public string BranchId { get; set; }

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime? UpdateAt { get; set; }
        
        /// <summary>
        /// Gets or sets the sale status.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        public List<UpdateSaleProductRequest> Products { get; set; }
    }
}
