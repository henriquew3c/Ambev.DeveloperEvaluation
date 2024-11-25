using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("The name cannot be null.");

            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("The price has be greater than 0.");
        }
    }
}
