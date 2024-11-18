using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CreateSale;

public class CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
    : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = mapper.Map<Sale>(command);

        sale.Calculate();

        var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
        var result = mapper.Map<CreateSaleResult>(createdSale);

        await mediator.Publish(new SaleCreatedEvent(createdSale), cancellationToken);

        return result;
    }
}