using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Events;

public class UserRegisteredEvent(User user)
{
    public User User { get; } = user;
}