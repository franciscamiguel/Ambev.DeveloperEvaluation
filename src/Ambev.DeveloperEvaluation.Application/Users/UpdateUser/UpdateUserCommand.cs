using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(
    Guid Id,
    string Username,
    string Password,
    string Phone,
    string Email,
    UserStatus Status,
    UserRole Role
) : IRequest<UpdateUserResult>
{
    public UpdateUserCommand() : this(default, string.Empty, string.Empty, string.Empty, string.Empty, default, default)
    {
    }
}