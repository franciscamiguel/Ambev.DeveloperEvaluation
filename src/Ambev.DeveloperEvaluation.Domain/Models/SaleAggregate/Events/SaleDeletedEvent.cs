using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;

public record SaleDeletedEvent(string SaleNumber) : IDomainEvent;