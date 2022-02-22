using Application.UseCases.AddIssue;
using Application.UseCases.AddIssueUseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using WebApi.Modules.Common.FeatureFlags;

namespace WebApi.V1.AddIssue;

[FeatureGate(Features.AddIssueUseCase)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public  class IssueController:ControllerBase
{
    [HttpPost("addissue")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddIssueResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> AddIssue(
        [FromServices] IAddIssueUseCase useCase,
        [FromServices] Presenter presenter,
        [FromBody] AddIssueRequest request)
    {
        useCase.OutputPort = presenter;

        var input = new AddIssueInput()
        {
            Title = request.Title,
            Description = request.Description,
            Points = request.Points,
            AssignedTo = request.AssignedTo,
            Status = request.Status,
        };

        await useCase.Execute(input);

        return presenter.ViewModel!;

    }
}
