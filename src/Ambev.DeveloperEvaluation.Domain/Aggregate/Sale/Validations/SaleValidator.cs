using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.CreateAt)
                .NotNull()
                .WithMessage("Date of the sale cannot be null.");

            RuleFor(sale => sale.CustomerId)
                .NotEmpty()
                .WithMessage("Customer Id cannot be null.");

            RuleFor(sale => sale.BranchId)
                .NotEmpty()
                .WithMessage("Branch Id cannot be null.");
        }
    }
}
