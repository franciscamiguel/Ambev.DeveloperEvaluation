using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate.Entities;

public class Branch : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}