using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.GetSale;

public sealed record GetSaleByIdQuery(Guid Id) : IRequest<GetSaleResult>;