using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductFeatures;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(product => product.UnitPrice).NotEmpty().NotNull().NotEqual(0);
    }
}