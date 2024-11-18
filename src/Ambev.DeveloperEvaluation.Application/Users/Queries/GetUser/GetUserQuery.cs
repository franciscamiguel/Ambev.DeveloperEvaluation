using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.Queries.GetUser;

/// <summary>
///     Command for retrieving a user by their ID
/// </summary>
public record GetUserQuery(Guid Id) : IRequest<GetUserResult>;