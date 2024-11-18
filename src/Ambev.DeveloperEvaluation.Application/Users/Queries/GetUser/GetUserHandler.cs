using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.Queries.GetUser;

/// <summary>
///     Handler for processing GetUserQuery requests
/// </summary>
public class GetUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetUserQuery, GetUserResult>
{
    /// <summary>
    ///     Handles the GetUserQuery request
    /// </summary>
    /// <param name="request">The GetUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);

        return user == null
            ? throw new KeyNotFoundException($"User with ID {request.Id} not found")
            : mapper.Map<GetUserResult>(user);
    }
}