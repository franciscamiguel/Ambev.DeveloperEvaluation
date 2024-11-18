using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using Ambev.DeveloperEvaluation.MessageBroker.Common;
using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Events;

public class SaleUpdatedEventHandler(IPublishEndpoint publishEndpoint) : IDomainEventHandler<SaleUpdatedEvent>
{
    public async Task Handle(SaleUpdatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await publishEndpoint.Publish<ISaleUpdated>(new
            {
                Success = true,
                notification.Sale
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