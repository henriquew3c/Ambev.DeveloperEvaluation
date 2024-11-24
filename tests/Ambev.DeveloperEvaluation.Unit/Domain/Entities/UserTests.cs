using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the User entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class UserTests
{
    /// <summary>
    /// Tests that when a suspended user is activated, their status changes to Active.
    /// </summary>
    [Fact(DisplayName = "User status should change to Active when activated")]
    public void Given_SuspendedUser_When_Activated_Then_StatusShouldBeActive()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Suspend();

        // Act
        user.Activate();

        // Assert
        Assert.Equal(UserStatus.Active, user.Status);
    }

    /// <summary>
    /// Tests that when an active user is suspended, their status changes to Suspended.
    /// </summary>
    [Fact(DisplayName = "User status should change to Suspended when suspended")]
    public void Given_ActiveUser_When_Suspended_Then_StatusShouldBeSuspended()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Activate();

        // Act
        user.Suspend();

        // Assert
        Assert.Equal(UserStatus.Suspended, user.Status);
    }

    /// <summary>
    /// Tests that validation passes when all user properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid data for creation user")]
    public void Given_ValidUserData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var command = UserTestData.GenerateValidCreateUserCommand();

        // Act
        var result = command.Map();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.ValidationResult.Errors);
    }

    /// <summary>
    /// Tests that validation fails when user properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid user data")]
    public void Given_InvalidUserData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var command = new CreateUserCommand()
        {
            Username = "", // Invalid: empty
            Password = UserTestData.GenerateInvalidPassword(), // Invalid: doesn't meet password requirements
            Email = UserTestData.GenerateInvalidEmail(), // Invalid: not a valid email
            Phone = UserTestData.GenerateInvalidPhone(), // Invalid: doesn't match pattern
            Status = UserStatus.Unknown, // Invalid: cannot be Unknown
            Role = UserRole.None // Invalid: cannot be None
        };

        // Act
        var result = command.Map();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.ValidationResult.Errors);
    }
}
