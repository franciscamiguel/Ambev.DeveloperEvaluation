using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using Ambev.DeveloperEvaluation.MessageBroker.Common;
using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Events;

public class ItemCancelledEventHandler(IPublishEndpoint publishEndpoint) : IDomainEventHandler<ItemCancelledEvent>
{
    public async Task Handle(ItemCancelledEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await publishEndpoint.Publish<IItemCancelled>(new
            {
                notification.Item
            }, cancellationToken);
        }
        catch (Exception ex)
        {
            await publishEndpoint.Publish<IResponse>(new
            {
                Success = false,
                Message = $"{ex.Message}-{ex.InnerException?.Message}"
            }, cancellationToken);
            throw;
        }
    }
}