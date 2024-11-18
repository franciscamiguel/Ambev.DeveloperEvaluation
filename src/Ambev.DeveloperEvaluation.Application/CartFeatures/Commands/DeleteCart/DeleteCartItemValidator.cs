using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.DeleteCart;

public class DeleteCartItemValidator : AbstractValidator<DeleteCartItemCommand>
{
    /// <summary>
    ///     Initializes validation rules for DeleteCartCommand
    /// </summary>
    public DeleteCartItemValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product is required");
    }
}