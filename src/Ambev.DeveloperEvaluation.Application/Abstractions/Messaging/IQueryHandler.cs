using Ambev.DeveloperEvaluation.Domain.Shared;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;