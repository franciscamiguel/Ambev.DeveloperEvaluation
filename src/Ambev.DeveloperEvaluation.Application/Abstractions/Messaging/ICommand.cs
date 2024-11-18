using Ambev.DeveloperEvaluation.Domain.Shared;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;