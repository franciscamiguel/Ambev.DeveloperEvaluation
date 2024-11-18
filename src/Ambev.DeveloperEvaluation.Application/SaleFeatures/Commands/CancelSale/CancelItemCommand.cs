using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CancelSale;

public sealed record CancelItemCommand(Guid SaleId, Guid ItemId) : IRequest<bool>;