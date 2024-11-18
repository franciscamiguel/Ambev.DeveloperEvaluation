using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(product => product.UnitPrice).NotEmpty().NotNull().NotEqual(0);
    }
}