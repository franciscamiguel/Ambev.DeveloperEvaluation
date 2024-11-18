using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.UpdateSale;

public sealed record UpdateSaleCommand(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemDto> Items
) : IRequest<UpdateSaleResult>
{
    public UpdateSaleCommand() : this(default, string.Empty, 0, false, null, null, [])
    {
    }
}