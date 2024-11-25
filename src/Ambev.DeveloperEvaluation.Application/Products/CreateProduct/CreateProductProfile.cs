using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between User entity and CreateProductResponse
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct operation
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<Product, CreateProductResult>();
    }
}
