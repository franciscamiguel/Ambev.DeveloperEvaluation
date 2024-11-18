using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CreateSale;

public sealed record CreateSaleCommand(
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemDto> Items) : IRequest<CreateSaleResult>
{
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}