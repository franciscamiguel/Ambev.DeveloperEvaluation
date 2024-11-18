using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public sealed record UpdateSaleRequest(
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemDto> Items);