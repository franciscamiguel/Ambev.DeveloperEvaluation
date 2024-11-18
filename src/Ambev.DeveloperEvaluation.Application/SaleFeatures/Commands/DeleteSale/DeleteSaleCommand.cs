using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.DeleteSale;

public sealed record DeleteSaleCommand(Guid Id) : IRequest<bool>;