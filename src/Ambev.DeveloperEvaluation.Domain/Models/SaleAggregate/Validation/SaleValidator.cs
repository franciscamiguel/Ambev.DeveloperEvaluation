using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().NotNull().Length(1, 50);
        RuleFor(sale => sale.TotalAmount).NotEmpty().NotEqual(0);
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Items cannot be empty")
            .Must(items => items != null && items.Count != 0).WithMessage("Sale must contain at least one item")
            .ForEach(item => item.SetValidator(new SaleItemValidator()));
    }
}