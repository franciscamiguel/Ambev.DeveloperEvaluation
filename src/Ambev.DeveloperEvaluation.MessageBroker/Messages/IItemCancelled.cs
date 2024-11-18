using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;
using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages;

public interface IItemCancelled : IResponse
{
    public SaleItemDto Item { get; set; }
}