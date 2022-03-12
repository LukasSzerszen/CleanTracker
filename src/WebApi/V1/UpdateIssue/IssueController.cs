using Application.UseCases.UpdateIssue;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Modules.Common.FeatureFlags;

namespace WebApi.V1.UpdateIssue;



[FeatureGate(Features.UpdateIssueUseCase)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public sealed class IssueController :ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> UpdateIssue(
    [FromServices] IUpdateIssueUseCase useCase,
    [FromServices] Presenter presenter,
    [FromQuery][Required] UpdateIssueRequest request)
    {
        useCase.OutputPort = presenter;

        UpdateIssueInput input = new(request.IssueId, 
            request.Title, 
            request.Description, 
            request.Points, 
            request.AssignedTo, 
            request.Status);

        await useCase.Execute(input);

        return presenter.ViewModel!;
    }
}
