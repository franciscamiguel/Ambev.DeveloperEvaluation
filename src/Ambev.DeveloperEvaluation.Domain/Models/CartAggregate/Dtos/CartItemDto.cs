namespace Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;

public sealed record CartItemDto(Guid Id, Guid ProductId, int Quantity)
{
    public CartItemDto() : this(default, default, default)
    {
    }
}