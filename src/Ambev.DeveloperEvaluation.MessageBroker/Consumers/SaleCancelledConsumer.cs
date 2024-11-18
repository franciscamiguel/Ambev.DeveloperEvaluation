using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers;

public class SaleCancelledConsumer : IConsumer<ISaleCancelled>
{
    public async Task Consume(ConsumeContext<ISaleCancelled> context)
    {
        try
        {
            Console.WriteLine("Message received at consumer");
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}