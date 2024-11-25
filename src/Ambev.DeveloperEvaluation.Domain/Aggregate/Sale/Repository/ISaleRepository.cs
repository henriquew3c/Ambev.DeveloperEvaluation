using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository
{
    /// <summary>
    /// Repository interface for Sale entity operations
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Update a sale in the repository
        /// </summary>
        /// <param name="sale">The sale to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated user</returns>
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);


        /// <summary>
        /// Add a new sale product in the repository
        /// </summary>
        /// <param name="product">The sale product to create</param>
        /// <returns>void</returns>
        Task AddSaleProductAsync(SaleProduct product);

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
