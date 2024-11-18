using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public sealed record CreateSaleRequest(
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemDto> Items);