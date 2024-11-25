using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using FluentValidation;
using Ambev.DeveloperEvaluation.Common.Exception;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale
{
    public partial class Sale : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Gets the sale's number.
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Gets the sale's status.
        /// </summary>
        public SaleStatus Status { get; private set; }

        /// <summary>
        /// Gets the sale's date.
        /// </summary>
        public DateTime CreateAt { get; private set; }

        /// <summary>
        /// Gets the sale's total.
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Gets the sale's discount.
        /// </summary>
        public decimal DiscountAmount { get; private set; }

        /// <summary>
        /// Gets the sale's discount percent.
        /// </summary>
        public decimal DiscountPercent { get; private set; }

        /// <summary>
        /// The readonly list of the sale items.
        /// </summary>
        private readonly List<SaleProduct> _products;

        /// <summary>
        /// The readonly collection of the sale items.
        /// </summary>
        public IReadOnlyCollection<SaleProduct> Products => _products;

        /// <summary>
        /// Gets the sale's customer id.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the sale's branch id.
        /// </summary>
        public Guid BranchId { get; private set; }

        /// <summary>
        /// Gets the sale's cancellation date.
        /// </summary>
        public DateTime? CancellationAt { get; private set; }


        /// <summary>
        /// Gets the sale's finished date.
        /// </summary>
        public DateTime? FinishedAt { get; private set; }

        /// <summary>
        /// Verify if sale product exists into sale.
        /// </summary>
        private bool SaleProductExists(SaleProduct product)
        {
            return _products.Any(p => p.ProductId == product.ProductId);
        }

        /// <summary>
        /// Add sale product into sale.
        /// </summary>
        public void AddProduct(SaleProduct saleProduct)
        {
            if (!saleProduct.IsValid) return;

            saleProduct.AssociateSale(Id);

            if (SaleProductExists(saleProduct))
            {
                var saleProductExistent = _products.FirstOrDefault(p => p.ProductId == saleProduct.ProductId);

                if (saleProductExistent == null)
                    return;

                _products.Remove(saleProductExistent);
            }

            _products.Add(saleProduct);
        }

        /// <summary>
        /// Get new sale.
        /// </summary>

        public Sale(string customerId, DateTime createAt, string branchId)
        {
            if (!customerId.ValidGuid())
            {
                this.ValidationResult.Errors.Add(new ValidationFailure(customerId, "Invalid user id."));
                throw new BusinessException();
            }
            
            if (!branchId.ValidGuid())
            {
                this.ValidationResult.Errors.Add(new ValidationFailure(branchId, "Invalid branch id."));
                throw new BusinessException();
            }

            Status = SaleStatus.Pending;
            _products = [];
            Number = new Random().Next(1, 10000).ToString();
            CreateAt = createAt;
            CustomerId = Guid.Parse(customerId);
            BranchId = Guid.Parse(branchId);
        }


        /// <summary>
        /// Apply sale's discount amount.
        /// </summary>
        public void ApplyDiscountAmount()
        {
            var amountItems = Products.Sum(p => p.Quantity);

            DiscountPercent = amountItems switch
            {
                >= 4 and < 10 => 0.10m,
                >= 10 and <= 20 => 0.20m,
                _ => 0.00m
            };

            DiscountAmount = (CalculateTotal() * DiscountPercent);
        }

        /// <summary>
        /// Calculate sum sale's total of the products.
        /// </summary>
        private decimal CalculateTotal()
        {

            return Products.Sum(p => p.Total);
        }


        /// <summary>
        /// Apply sale's total anount.
        /// </summary>
        public void ApplyTotalAmount()
        {

            TotalAmount = Products.Sum(p => p.Total) - DiscountAmount;
        }

        public Sale()
        {

        }

        public void Cancel()
        {
            Status = SaleStatus.Cancelled;
            CancellationAt = DateTime.Now;
        }

        public void Finish()
        {
            Status = SaleStatus.Finish;
            FinishedAt = DateTime.Now;
        }
    }
}
