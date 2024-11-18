using Ambev.DeveloperEvaluation.Domain.Models.UserAggregate;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await userRepository.GetByIdAsync(command.Id, cancellationToken)
                   ?? throw new Exception($"User with Id {command.Id} not found.");

        user.Update(command.Username, command.Password, command.Phone, command.Email, command.Status,
            command.Role);

        var updatedUser = await userRepository.UpdateAsync(user, cancellationToken);

        return mapper.Map<UpdateUserResult>(updatedUser);
    }
}