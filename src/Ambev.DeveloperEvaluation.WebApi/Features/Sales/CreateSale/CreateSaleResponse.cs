namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public sealed record CreateSaleResponse
{
    public Guid Id { get; set; }
    public string SaleNumber { get; init; } = string.Empty;
    public decimal TotalAmount { get; init; }
    public bool IsCancelled { get; init; }
    public Guid? CustomerId { get; init; }
    public Guid? BranchId { get; init; }
}