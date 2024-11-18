using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CancelSale;

public class CancelSaleCommandHandler(ISaleRepository saleRepository, IMediator mediator)
    : IRequestHandler<CancelSaleCommand, bool>
{
    public async Task<bool> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await saleRepository.GetByIdAsync(command.SaleId, cancellationToken)
                   ?? throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found.");

        sale.Cancel();

        await saleRepository.UpdateAsync(sale, cancellationToken);

        await mediator.Publish(new SaleCancelledEvent(sale), cancellationToken);

        return true;
    }
}