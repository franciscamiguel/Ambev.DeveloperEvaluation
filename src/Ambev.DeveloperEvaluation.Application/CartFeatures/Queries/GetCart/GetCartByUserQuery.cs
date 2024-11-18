using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Queries.GetCart;

public sealed record GetCartByUserQuery(Guid UserId) : IRequest<GetCartResult>;