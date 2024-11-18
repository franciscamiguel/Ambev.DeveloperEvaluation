using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CancelSale;

public class CancelItemCommandHandler(ISaleRepository saleRepository, IMediator mediator)
    : IRequestHandler<CancelItemCommand, bool>
{
    public async Task<bool> Handle(CancelItemCommand command, CancellationToken cancellationToken)
    {
        var sale = await saleRepository.GetByIdAsync(command.SaleId, cancellationToken)
                   ?? throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found.");

        var item = sale.Items.FirstOrDefault(i => i.Id == command.ItemId)
                   ?? throw new KeyNotFoundException($"Item with ID {command.ItemId} not found in sale.");

        sale.CancelItem(command.ItemId);

        await saleRepository.UpdateAsync(sale, cancellationToken);

        await mediator.Publish(new ItemCancelledEvent(sale, item), cancellationToken);

        return true;
    }
}