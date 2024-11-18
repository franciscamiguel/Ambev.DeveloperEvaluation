namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public sealed record CreateCustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string ExternalId { get; init; } = string.Empty;
}