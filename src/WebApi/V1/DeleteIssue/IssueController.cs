using Application.UseCases.DeleteIssue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Modules.Common.FeatureFlags;

namespace WebApi.V1.DeleteIssue;

[FeatureGate(Features.DeleteIssueUseCase)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public sealed class IssueController : ControllerBase
{
    [HttpPost("deleteissue")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> UpdateIssue(
        [FromServices] IDeleteIssueUseCase useCase,
        [FromServices] Presenter presenter,
        [FromBody][Required] DeleteIssueRequest request)
    {
        useCase.OutputPort = presenter;
         
        DeleteIssueInput input = new(request.IssueId);

        await useCase.Execute(input);

        return presenter.ViewModel!;
    }
}
