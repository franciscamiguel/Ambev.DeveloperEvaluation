using Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CancelSale;
using Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.DeleteSale;
using Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.UpdateSale;
using Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries;
using Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.GetSale;
using Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.ListSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController(IMediator mediator, IMapper mapper) : BaseController
{
    /// <summary>
    ///     Creates a new sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = mapper.Map<CreateSaleCommand>(request);
        var response = await mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = mapper.Map<CreateSaleResponse>(response)
        });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSaleRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = mapper.Map<UpdateSaleCommand>(request) with { Id = id };

        var response = await mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateSaleResult>
        {
            Success = true,
            Message = "Sale updated successfully",
            Data = response
        });
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteSaleCommand(id), cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetSaleByIdQuery(id), cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleResult>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = response
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<IEnumerable<GetSaleResult>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new ListSalesQuery(), cancellationToken);

        return Ok(new ApiResponseWithData<IEnumerable<GetSaleResult>>
        {
            Success = true,
            Message = "Sales retrieved successfully",
            Data = response
        });
    }

    [HttpPatch("cancel/{id:guid}")]
    public async Task<IActionResult> Cancel([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new CancelSaleCommand(id), cancellationToken);
        
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale cancelled successfully"
        });
    }

    [HttpPatch("cancel-item/{saleId:guid}/{itemId:guid}")]
    public async Task<IActionResult> CancelItem([FromRoute] Guid saleId, [FromRoute] Guid itemId,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new CancelItemCommand(saleId, itemId), cancellationToken);
        
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Item cancelled successfully"
        });
    }
}