using Ambev.DeveloperEvaluation.Domain.Aggregate.User;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation for ActiveUserSpecification tests
/// to ensure consistency across test cases.
/// </summary>
public static class ActiveUserSpecificationTestData
{
    /// <summary>
    /// Configures the Faker to generate valid User entities.
    /// The generated users will have valid:
    /// - Email (valid format)
    /// - Password (meeting complexity requirements)
    /// - FirstName
    /// - LastName
    /// - Phone (Brazilian format)
    /// - Role (User)
    /// Status is not set here as it's the main test parameter
    /// </summary>
    private static readonly Faker<User> userFaker = new Faker<User>()
        .CustomInstantiator(f => new User(f.Name.FirstName(), 
            f.Internet.Email(), 
            $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}", 
            $"Test@{f.Random.Number(100, 999)}", f.PickRandom<UserRole>(), 
            f.PickRandom<UserStatus>())
        );

    /// <summary>
    /// Generates a valid User entity with the specified status.
    /// </summary>
    /// <param name="status">The UserStatus to set for the generated user.</param>
    /// <returns>A valid User entity with randomly generated data and specified status.</returns>
    public static User GenerateUser(UserStatus status)
    {
        var user = userFaker.Generate();

        switch (status)
        {
            case UserStatus.Active:
                user.Activate();
                break;
            case UserStatus.Suspended:
                user.Suspend();
                break;
            case UserStatus.Inactive:
                user.Deactivate();
                break;
            case UserStatus.Unknown:
            default:
                break;
        }

        return user;
    }
}
