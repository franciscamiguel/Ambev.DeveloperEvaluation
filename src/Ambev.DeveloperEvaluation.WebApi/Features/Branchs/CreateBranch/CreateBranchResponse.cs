namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

public sealed record CreateBranchResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
}