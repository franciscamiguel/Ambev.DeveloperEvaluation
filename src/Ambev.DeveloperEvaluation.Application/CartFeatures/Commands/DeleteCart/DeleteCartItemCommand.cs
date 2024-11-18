using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.DeleteCart;

public sealed record DeleteCartItemCommand(Guid UserId, Guid ProductId) : IRequest<bool>;