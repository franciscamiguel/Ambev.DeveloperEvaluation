using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers;

public class SaleDeletedConsumer : IConsumer<ISaleDeleted>
{
    public async Task Consume(ConsumeContext<ISaleDeleted> context)
    {
        try
        {
            Console.WriteLine("Mensagem recebida no consumidor");
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}