using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;
using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages;

public interface ISaleCancelled : IResponse
{
    public SaleDto Sale { get; set; }
}