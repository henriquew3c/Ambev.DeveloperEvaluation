using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid CreateProductCommand object.
    /// The generated users will have valid:
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    private static readonly Faker<CreateProductCommand> CreateProductCommandFaker = new Faker<CreateProductCommand>()
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));


    /// <summary>
    /// Generates a valid CreateProductCommand object with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static CreateProductCommand GenerateValidCreateProductCommand()
    {
        return CreateProductCommandFaker.Generate();
    }

    /// <summary>
    /// Generates a valid product name.
    /// The generated product name will:
    /// - Be between 3 and 50 characters
    /// - Use internet username conventions
    /// - Contain only valid characters
    /// </summary>
    /// <returns>A valid username.</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Generates a product name that exceeds the maximum length limit.
    /// The generated product name will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing product name length validation error cases.
    /// </summary>
    /// <returns>A product name that exceeds the maximum length limit.</returns>
    public static string GenerateLongProductName()
    {
        return new Faker().Random.String2(51);
    }

    public static string GenerateEmptyProductName()
    {
        return new Faker().Random.String2(0);
    }

    public static decimal GenerateInvalidProductPrice()
    {
        return decimal.Zero;
    }

    public static decimal GenerateValidProductPrice()
    {
        return decimal.Parse(new Faker().Commerce.Price(1m, 1000m));
    }
}