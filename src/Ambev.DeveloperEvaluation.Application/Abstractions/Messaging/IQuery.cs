using Ambev.DeveloperEvaluation.Domain.Shared;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;