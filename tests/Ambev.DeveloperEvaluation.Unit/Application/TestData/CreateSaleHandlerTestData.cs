using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid CreateSaleCommand object.
    /// The generated users will have valid:
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    private static readonly Faker<CreateSaleCommand> CreateSaleCommandFaker = new Faker<CreateSaleCommand>()
        .RuleFor(p => p.BranchId, f => f.Random.Guid().ToString())
        .RuleFor(p => p.CustomerId, f => f.Random.Guid().ToString())
        .RuleFor(p => p.Date, f => f.Date.Recent());


    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return CreateSaleCommandFaker.Generate();
    }
}
