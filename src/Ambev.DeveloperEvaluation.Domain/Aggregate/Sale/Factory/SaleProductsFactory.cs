using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.DTO;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory;

public static class SaleProductsFactory
{
    public static List<Aggregate.Sale.SaleProduct> Create(List<SaleProductDTO> products)
    {
        var saleProducts = new List<Aggregate.Sale.SaleProduct>();

        products.ForEach(product =>
        {
            var saleProduct = new Aggregate.Sale.SaleProduct(product.ProductId, product.Quantity);
            saleProduct.Validate(saleProduct, new SaleProductValidator());
            saleProducts.Add(saleProduct);
        });

        return saleProducts;
    }
}