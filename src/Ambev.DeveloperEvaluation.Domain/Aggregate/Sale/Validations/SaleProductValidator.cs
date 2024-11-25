using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations;

public class SaleProductValidator : AbstractValidator<SaleProduct>
{
    public SaleProductValidator()
    {
        RuleFor(sale => sale.Quantity)
            .GreaterThan(0)
            .LessThanOrEqualTo(20)
            .WithMessage("Quantity for product is not allowed.");

        RuleFor(sale => sale.ProductId)
            .NotEmpty()
            .WithMessage("One or more product id is not valid.");
    }
}