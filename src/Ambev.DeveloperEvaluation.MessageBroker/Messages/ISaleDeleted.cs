using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages;

public interface ISaleDeleted : IResponse
{
    public string SaleNumber { get; set; }
}