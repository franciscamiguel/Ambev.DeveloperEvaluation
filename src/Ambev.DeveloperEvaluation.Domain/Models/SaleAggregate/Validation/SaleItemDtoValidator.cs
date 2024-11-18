using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Validation;

public class SaleItemDtoValidator : AbstractValidator<SaleItemDto>
{
    public SaleItemDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero");
    }
}