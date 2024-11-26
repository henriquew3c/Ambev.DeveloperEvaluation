using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid CreateSaleCommand object.
    /// The generated sales will have valid:
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    private static readonly Faker<CreateSaleCommand> CreateSaleCommandFaker = new Faker<CreateSaleCommand>()
        .RuleFor(s => s.Date, f => f.Date.Past())
        .RuleFor(s => s.CustomerId, f => f.Random.Guid().ToString())
        .RuleFor(s => s.BranchId, f => f.Random.Guid().ToString());

    /// <summary>
    /// Generates a valid CreateProductCommand object with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCreateSaleCommand()
    {
        return CreateSaleCommandFaker.Generate();
    }

    private static readonly Faker<SaleProduct> SaleProductFaker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), decimal.Parse(f.Commerce.Price(1m, 100m))))
        .RuleFor(i => i.Quantity, f => f.Random.Number(1, 3))
        .RuleFor(i => i.IsValid, true);

    public static readonly Faker<SaleProduct> SaleProductInvalidFaker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), decimal.Parse(f.Commerce.Price(1m, 100m))))
        .RuleFor(i => i.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(i => i.IsValid, true);

    /// <summary>
    /// Generates a valid list of SaleProduct entities with randomized data.
    /// </summary>
    /// <param name="count">The number of items to generate</param>
    /// <returns>A list of valid SaleItem entities.</returns>
    public static List<SaleProduct> GenerateValidSaleProducts(int count)
    {
        return SaleProductFaker.Generate(count);
    }
}