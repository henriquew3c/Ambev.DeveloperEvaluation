using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("The price has be greater than 0.");
        }
    }
}
