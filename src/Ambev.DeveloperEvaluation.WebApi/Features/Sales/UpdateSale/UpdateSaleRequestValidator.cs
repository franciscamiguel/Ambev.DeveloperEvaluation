using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().NotNull().Length(1, 50);
        RuleFor(sale => sale.TotalAmount).NotEmpty().NotEqual(0);
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Items cannot be empty")
            .Must(items => items != null && items.Any()).WithMessage("Sale must contain at least one item")
            .ForEach(item => item.SetValidator(new SaleItemDtoValidator()));
    }
}