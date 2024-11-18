using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public decimal UnitPrice { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}