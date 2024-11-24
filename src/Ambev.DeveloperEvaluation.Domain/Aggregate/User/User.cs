using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.User;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public partial class User : BaseEntity, IUser, IAggregateRoot
{
    /// <summary>
    /// Gets the user's full name.
    /// Must not be null or empty and should contain both first and last names.
    /// </summary>
    public string? Username { get; private set;} = string.Empty;

    /// <summary>
    /// Gets the user's email address.
    /// Must be a valid email format and is used as a unique identifier for authentication.
    /// </summary>
    public string Email { get; private set;} = string.Empty;

    /// <summary>
    /// Gets the user's phone number.
    /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; private set;} = string.Empty;

    /// <summary>
    /// Gets the hashed password for authentication.
    /// Password must meet security requirements: minimum 8 characters, at least one uppercase letter,
    /// one lowercase letter, one number, and one special character.
    /// </summary>
    public string Password { get; private set;} = string.Empty;

    /// <summary>
    /// Gets the user's role in the system.
    /// Determines the user's permissions and access levels.
    /// </summary>
    public UserRole Role { get; private set;}

    /// <summary>
    /// Gets the user's current status.
    /// Indicates whether the user is active, inactive, or blocked in the system.
    /// </summary>
    public UserStatus Status { get; private set;}

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; private set;}

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; private set;}

    /// <summary>
    /// Gets the unique identifier of the user.
    /// </summary>
    /// <returns>The user's ID as a string.</returns>
    string IUser.Id => Id.ToString();

    /// <summary>
    /// Gets the username.
    /// </summary>
    /// <returns>The username.</returns>
    string IUser.Username => Username;

    /// <summary>
    /// Gets the user's role in the system.
    /// </summary>
    /// <returns>The user's role as a string.</returns>
    string IUser.Role => Role.ToString();

    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Activates the user account.
    /// Changes the user's status to Active.
    /// </summary>
    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Deactivates the user account.
    /// Changes the user's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Blocks the user account.
    /// Changes the user's status to Blocked.
    /// </summary>
    public void Suspend()
    {
        Status = UserStatus.Suspended;
        UpdatedAt = DateTime.UtcNow;
    }

    // <summary>
    /// Set status to unknown the user account.
    /// Changes the user's status to Unknown.
    /// </summary>

    public void SetStatusUnknown()
    {
        Status = UserStatus.Unknown;
        UpdatedAt = DateTime.UtcNow;
    }

    // <summary>
    /// Clear the user's role.
    /// </summary>
    public void ClearRole()
    {
        Role = UserRole.None;
        UpdatedAt = DateTime.UtcNow;
    }

    // <summary>
    /// Set the user's password.
    /// </summary>
    public void SetPassword(string password)
    {
        this.Password = password;
        UpdatedAt = DateTime.UtcNow;
    }

    // <summary>
    /// Set the user's phone.
    /// </summary>
    public void SetPhone(string phone)
    {
        this.Phone = phone;
        UpdatedAt = DateTime.UtcNow;
    }

    // <summary>
    /// Set the user's name.
    /// </summary>
    public void SetUsername(string username)
    {
        this.Username = username;
        UpdatedAt = DateTime.UtcNow;
    }

    // <summary>
    /// Set the user's email.
    /// </summary>
    public void SetEmail(string email)
    {
        this.Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public User(string username, string email, string phone, string password, UserRole role, UserStatus status)
    {
        Username = username;
        Email = email;
        Phone = phone;
        Password = password;
        Role = role;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }
}

