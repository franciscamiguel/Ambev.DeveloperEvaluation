using Ambev.DeveloperEvaluation.Application.BranchFeatures;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs;

[ApiController]
[Route("api/[controller]")]
public class BranchsController(IMediator mediator, IMapper mapper) : BaseController
{
    /// <summary>
    ///     Creates a new branch
    /// </summary>
    /// <param name="request">The branch creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created branch details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = mapper.Map<CreateBranchCommand>(request);
        var response = await mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
        {
            Success = true,
            Message = "Branch created successfully",
            Data = mapper.Map<CreateBranchResponse>(response)
        });
    }
}