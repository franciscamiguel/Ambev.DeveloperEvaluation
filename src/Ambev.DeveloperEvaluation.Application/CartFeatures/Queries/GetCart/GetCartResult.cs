using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Queries.GetCart;

public sealed record GetCartResult(
    Guid Id,
    Guid UserId,
    DateTime CreatedAt,
    IEnumerable<CartItemDto> Products);