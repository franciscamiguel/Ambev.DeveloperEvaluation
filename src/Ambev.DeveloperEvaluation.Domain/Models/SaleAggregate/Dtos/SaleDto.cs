namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

public sealed record SaleDto(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<SaleItemDto>? Items)
{
    public SaleDto() : this(Guid.Empty, string.Empty, 0, default, Guid.Empty, Guid.Empty, default, default, default)
    {
    }
}