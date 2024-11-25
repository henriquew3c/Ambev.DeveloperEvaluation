using Ambev.DeveloperEvaluation.Common.Exception;
using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User;
using Ambev.DeveloperEvaluation.Domain.Common;
using FluentValidation;
using FluentValidation.Results;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;

public class SaleProduct: BaseEntity
{
    /// <summary>
    /// Gets the sale item's product.
    /// </summary>
    public Product.Product? Product { get; set; }

    /// <summary>
    /// Gets the sale item's product id.
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Gets the sale item quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the item sale id.
    /// </summary>
    public Guid SaleId { get; private set; }

    /// <summary>
    /// Gets sale item's total.
    /// </summary>
    public decimal Total => Product?.Price * Quantity ?? 0;

    /// <summary>
    /// Associate this item to a sale.
    /// </summary>
    internal void AssociateSale(Guid saleId)
    {
        SaleId = saleId;
    }

    public SaleProduct(string productId, int quantity)
    {
        if (productId.ValidGuid())
        {
            ProductId = Guid.Parse(productId);
        }

        Quantity = quantity;
    }

    public SaleProduct()
    {
        
    }
}