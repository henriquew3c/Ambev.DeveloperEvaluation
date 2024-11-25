using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public GetSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
