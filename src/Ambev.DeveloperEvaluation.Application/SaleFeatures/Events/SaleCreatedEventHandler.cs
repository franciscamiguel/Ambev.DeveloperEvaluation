using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using Ambev.DeveloperEvaluation.MessageBroker.Common;
using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Events;

public class SaleCreatedEventHandler(IPublishEndpoint publishEndpoint) : IDomainEventHandler<SaleCreatedEvent>
{
    public async Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await publishEndpoint.Publish<ISaleCreated>(new
            {
                Success = true,
                notification.Sale,
                Message = ""
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