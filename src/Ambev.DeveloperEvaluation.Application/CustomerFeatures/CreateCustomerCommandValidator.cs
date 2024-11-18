using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CustomerFeatures;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(customer => customer.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(customer => customer.ExternalId).NotEmpty().NotNull().Length(1, 50);
    }
}