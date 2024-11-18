using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateOrUpdateCart;
using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.DeleteCart;
using Ambev.DeveloperEvaluation.Application.CartFeatures.Queries.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateOrUpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

[ApiController]
[Route("api/[controller]")]
public class CartsController (IMediator mediator, IMapper mapper) : BaseController
{
    [HttpPut("create-or-update-item/{userId:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateOrUpdateCartResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrUpdate([FromRoute] Guid userId, [FromBody] CartItemRequest request,
        CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddOrUpdateCartItemCommand>(request) with { UserId = userId };

        var response = await mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<CreateOrUpdateCartResult>
        {
            Success = true,
            Message = "Cart updated successfully",
            Data = response
        });
    }
    
    [HttpDelete("remove-item/{userId:guid}/{productId:guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid userId, Guid productId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteCartItemCommand(userId, productId), cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Cart deleted successfully"
        });
    }
    
    [HttpGet("get-by-userid/{userId:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartById([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetCartByUserQuery(userId), cancellationToken);

        return Ok(new ApiResponseWithData<GetCartResult>
        {
            Success = true,
            Message = "Cart retrieved successfully",
            Data = response
        });
    }
}