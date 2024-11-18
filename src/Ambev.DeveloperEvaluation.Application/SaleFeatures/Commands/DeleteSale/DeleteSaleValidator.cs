using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.DeleteSale;

public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    ///     Initializes validation rules for DeleteSaleCommand
    /// </summary>
    public DeleteSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}