using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.GetSale;

public class GetSaleByIdQueryHandler(ISaleRepository saleRepository, IMapper mapper)
    : IRequestHandler<GetSaleByIdQuery, GetSaleResult>
{
    public async Task<GetSaleResult> Handle(GetSaleByIdQuery query, CancellationToken cancellationToken)
    {
        var sale = await saleRepository.GetByIdAsync(query.Id, cancellationToken);
        if (sale == null) throw new Exception($"Sale with Id {query.Id} not found.");

        return mapper.Map<GetSaleResult>(sale);
    }
}