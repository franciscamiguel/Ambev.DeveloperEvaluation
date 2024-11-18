using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.BranchFeatures;

public sealed record CreateBranchCommand(
    string Name,
    string Location) : IRequest<CreateBranchResult>
{
    public ValidationResultDetail Validate()
    {
        var validator = new CreateBranchCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}