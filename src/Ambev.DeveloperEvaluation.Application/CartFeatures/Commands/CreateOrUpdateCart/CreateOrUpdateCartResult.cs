using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateOrUpdateCart;

public sealed record CreateOrUpdateCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<CartItemDto>? Products { get; set; }
}