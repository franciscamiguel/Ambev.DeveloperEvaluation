using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateOrUpdateCart;

public class AddOrUpdateCartItemCommandValidator : AbstractValidator<AddOrUpdateCartItemCommand>
{
    public AddOrUpdateCartItemCommandValidator()
    {
        RuleFor(cart => cart.ProductId).NotEmpty().WithMessage("ProductId cannot be empty.");
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
        RuleFor(cart => cart.Quantity).NotEmpty().NotEqual(0).WithMessage("Quantity cannot be empty.");
    }
}