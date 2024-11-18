using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.DeleteSale;

public class DeleteSaleCommandHandler(ISaleRepository saleRepository, IMediator mediator)
    : IRequestHandler<DeleteSaleCommand, bool>
{
    public async Task<bool> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await saleRepository.GetByIdAsync(command.Id, cancellationToken)
                   ?? throw new Exception($"Sale with Id {command.Id} not found.");

        var deletedSale = await saleRepository.DeleteAsync(sale.Id, cancellationToken);
        if (!deletedSale) throw new Exception($"Sale with Id {command.Id} not deleted.");

        await mediator.Publish(new SaleDeletedEvent(sale.SaleNumber), cancellationToken);

        return true;
    }
}