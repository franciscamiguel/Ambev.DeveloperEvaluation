using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.UpdateSale;

public class UpdateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
    : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await saleRepository.GetByIdAsync(command.Id, cancellationToken)
                   ?? throw new Exception($"Sale with Id {command.Id} not found.");

        sale.Update(command.TotalAmount, command.IsCancelled, command.CustomerId, command.BranchId);

        var items = mapper.Map<SaleItem[]>(command.Items);
        
        sale.UpdateItems(items);

        var updatedSale = await saleRepository.UpdateAsync(sale, cancellationToken);

        await mediator.Publish(new SaleUpdatedEvent(updatedSale), cancellationToken);

        return mapper.Map<UpdateSaleResult>(updatedSale);
    }
}