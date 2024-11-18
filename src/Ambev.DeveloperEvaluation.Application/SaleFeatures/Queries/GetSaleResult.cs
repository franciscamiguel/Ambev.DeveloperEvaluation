using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries;

public sealed record GetSaleResult(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<SaleItemDto> Items);