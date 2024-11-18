using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CancelSale;

public sealed record CancelSaleCommand(Guid SaleId) : IRequest<bool>;