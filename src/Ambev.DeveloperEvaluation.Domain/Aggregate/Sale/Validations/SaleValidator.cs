using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.Date)
                .NotNull()
                .WithMessage("Date of the sale cannot be null.");

            RuleFor(sale => sale.UserId)
                .NotEmpty()
                .WithMessage("User Id cannot be null.");
        }
    }
}
