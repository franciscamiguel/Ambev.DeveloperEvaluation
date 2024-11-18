using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateOrUpdateCart;

public sealed record AddOrUpdateCartItemCommand(Guid UserId, Guid ProductId, int Quantity
) : IRequest<CreateOrUpdateCartResult>
{
    public AddOrUpdateCartItemCommand() : this(Guid.Empty, Guid.Empty, default) { }
}