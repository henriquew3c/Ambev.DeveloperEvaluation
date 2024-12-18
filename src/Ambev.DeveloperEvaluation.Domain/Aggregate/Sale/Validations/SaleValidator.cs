﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Validations
{
    public class CreateSaleValidator : AbstractValidator<Sale>
    {
        public CreateSaleValidator()
        {
            RuleFor(sale => sale.CreateAt)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Date cannot is valid.");

            RuleFor(user => user.CustomerId).SetValidator(new CustomerValidator());
            RuleFor(user => user.BranchId).SetValidator(new CustomerValidator());
        }
    }
    
    public class UpdateSaleValidator : AbstractValidator<Sale>
    {
        public UpdateSaleValidator()
        {
            RuleFor(sale => sale.UpdateAt)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Date cannot is valid.");

            RuleFor(user => user.CustomerId).SetValidator(new CustomerValidator());
            RuleFor(user => user.BranchId).SetValidator(new CustomerValidator());
        }
    }

    public class CustomerValidator : AbstractValidator<Guid>
    {
        public CustomerValidator()
        {
            RuleFor(customerId => customerId)
                .NotEmpty()
                .WithMessage("Customer Id cannot be null.");
        }
    }
    
    public class BranchValidator : AbstractValidator<Guid>
    {
        public BranchValidator()
        {
            RuleFor(branchId => branchId)
                .NotEmpty()
                .WithMessage("Branch Id cannot be null.");
        }
    }
}
