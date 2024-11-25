using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using FluentValidation;
using Ambev.DeveloperEvaluation.Common.Exception;
using FluentValidation.Results;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;

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
        /// Add sale product into sale.
        /// </summary>
        public void AddProduct(SaleProduct saleProduct)
        {
            if (!saleProduct.IsValid) return;

            saleProduct.AssociateSale(Id);

            if (!SaleProductExists(saleProduct))
            {
                _products.Add(saleProduct);
                return;
            }
            
            IncreaseQuantityIntoSaleProductExistent(saleProduct);
        }

        private void IncreaseQuantityIntoSaleProductExistent(SaleProduct saleProduct)
        {
            var saleProductExistent = _products.FirstOrDefault(p => p.ProductId == saleProduct.ProductId);

            if (saleProductExistent == null)
                return;

            var newQuantity = saleProductExistent.Quantity + saleProduct.Quantity;

            if (newQuantity > 20)
            {
                throw new ValidationException(
                    new List<ValidationFailure> { new ValidationFailure("products", $"Product's identical quantity not be more 20.") }
                );
            }

            saleProductExistent.Quantity = newQuantity;

        }

        /// <summary>
        /// Clear sale product into sale.
        /// </summary>
        public void ClearProducts()
        {
            _products.Clear();
        }

        /// <summary>
        /// Verify if sale product exists into sale.
        /// </summary>
        private bool SaleProductExists(SaleProduct product)
        {
            return _products.Any(p => p.ProductId == product.ProductId);
        }

        /// <summary>
        /// Get new sale.
        /// </summary>

        public Sale(string customerId, string branchId, DateTime? createAt = null, DateTime? updateAt = null)
        {

            Status = SaleStatus.Pending;
            _products = [];
            Number = new Random().Next(1, 10000).ToString();

            if (createAt.HasValue)
                CreateAt = createAt.Value;

            if (updateAt.HasValue)
                UpdateAt = updateAt.Value;

            if (customerId.ValidGuid())
                CustomerId = Guid.Parse(customerId);

            if (branchId.ValidGuid())
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
            CancellationAt = DateTime.Now.ToUniversalTime();
        }

        public void Finish()
        {
            Status = SaleStatus.Finish;
            FinishedAt = DateTime.Now.ToUniversalTime();
        }

        public void Update(Sale newSale, SaleStatus newStatus)
        {
            CustomerId = newSale.CustomerId;
            BranchId = newSale.BranchId;
            UpdateAt = newSale.UpdateAt;

            switch (newStatus)
            {
                case SaleStatus.Cancelled:
                    Cancel();
                    break;
                case SaleStatus.Finish:
                    Finish();
                    break;
                case SaleStatus.Unknown:
                case SaleStatus.Pending:
                default:
                    break;
            }
        }
    }
}
