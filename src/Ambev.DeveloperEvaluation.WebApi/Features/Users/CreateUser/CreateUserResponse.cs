using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class CreateUserResponse
{
    /// <summary>
    /// The unique identifier of the created user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's full name
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// The current status of the user
    /// </summary>
    public UserStatus Status { get; set; }
}
