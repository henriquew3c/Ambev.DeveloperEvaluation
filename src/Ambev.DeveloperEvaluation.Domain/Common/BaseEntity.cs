using FluentValidation.Internal;
using FluentValidation;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public abstract class BaseEntity : IComparable<BaseEntity>
{
    /// <summary>
    /// Gets the entity identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the update at.
    /// </summary>
    public DateTime UpdateAt { get; set; }

    // <summary>
    /// Gets the entity validate status.
    /// </summary>
    public bool IsValid { get; private set; }

    public bool IsInvalid => !IsValid;

    // <summary>
    /// Gets the entity validation result.
    /// </summary>
    public ValidationResult ValidationResult { get; set; }

    public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return IsValid = ValidationResult.IsValid;
    }

    public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator, Action<ValidationStrategy<TModel>> options)
    {
        ValidationResult = validator.Validate(model, options);
        return IsValid = ValidationResult.IsValid;
    }

    public int CompareTo(BaseEntity? other)
    {
        if (other == null)
        {
            return 1;
        }

        return other!.Id.CompareTo(Id);
    }
}
