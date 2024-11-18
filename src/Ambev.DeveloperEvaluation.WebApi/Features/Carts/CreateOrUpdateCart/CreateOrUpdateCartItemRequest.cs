namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateOrUpdateCart;

public sealed record CartItemRequest(Guid ProductId, int Quantity);