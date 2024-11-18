using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    public CreateBranchRequestValidator()
    {
        RuleFor(branch => branch.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(branch => branch.Location).NotEmpty().NotNull().Length(3, 50);
    }
}