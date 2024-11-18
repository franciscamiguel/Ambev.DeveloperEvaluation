namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public sealed record CreateProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public decimal UnitPrice { get; init; }
}