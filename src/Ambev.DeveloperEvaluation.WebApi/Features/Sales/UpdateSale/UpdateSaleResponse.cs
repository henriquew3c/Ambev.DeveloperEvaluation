﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// API response model for CreateSale operation.
    /// </summary>
    public class UpdateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public Guid? CustomerId { get; set; } = null;

        /// <summary>
        /// Gets or sets the branch id.
        /// </summary>
        public Guid? BranchId { get; set; } = null;

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime? CreateAt { get; set; } = null;

        /// <summary>
        /// The list of sale items.
        /// </summary>
        public List<UpdateSaleProductResponse> Products { get; set; } = new();

        /// <summary>
        /// Gets or sets the sale status.
        /// </summary>
        public string Status { get; set; }
    }
}