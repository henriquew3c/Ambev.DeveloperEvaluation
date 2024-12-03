using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Represents the response returned after successfully creating a new user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateUserResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created user in the system.</value>
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
