using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Factory;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public static class CreateProductAdapter
    {
        public static Product Map(this CreateProductCommand request)
        {
            return ProductFactory.Create(request.Name, request.Price);
        }
    }
}



