using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleProductsHandlerTestData
{
    private static readonly Faker<SaleProduct> SaleProductFaker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), decimal.Parse(f.Commerce.Price(1m, 100m))))
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => f.Random.Number(1, 3))
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

    private static readonly Faker<SaleProduct> SaleProductTo20PercentDiscountFaker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), 100m))
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => 10)
        .RuleFor(i => i.IsValid, true);

    public static SaleProduct GenerateSaleProductTo20PercentDiscount()
    {
        return SaleProductTo20PercentDiscountFaker.Generate();
    }

    private static readonly Faker<SaleProduct> SaleProductTo10PercentDiscountFaker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), 100m))
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => 5)
        .RuleFor(i => i.IsValid, true);

    public static SaleProduct GenerateSaleProductTo10PercentDiscount()
    {
        return SaleProductTo10PercentDiscountFaker.Generate();
    }
    
    private static readonly Faker<SaleProduct> SaleProductAbove20IdenticalFaker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), 100m))
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => 21)
        .RuleFor(i => i.IsValid, true);

    public static SaleProduct GenerateSaleProductAbove20Identical()
    {
        return SaleProductAbove20IdenticalFaker.Generate();
    }
    
    private static readonly Faker<SaleProduct> SaleProductBelow4Faker = new Faker<SaleProduct>()
        .RuleFor(i => i.Product, f => new Product(f.Commerce.ProductName(), 100m))
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => 3)
        .RuleFor(i => i.IsValid, true);

    public static SaleProduct GenerateSaleProductBelow4Identical()
    {
        return SaleProductBelow4Faker.Generate();
    }
}
