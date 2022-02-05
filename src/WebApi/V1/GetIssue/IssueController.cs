using Application.UseCases.GetIssue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;
using WebApi.Modules.Common.FeatureFlags;
using WebApi.V1.GetIssue;

namespace WebApi.Controllers;

[FeatureGate(Features.GetIssueUseCase)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    [HttpGet("{IssueId:guid}", Name = "GetIssueV1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> GetIssue(
        [FromServices] IGetIssueUseCase useCase,
        [FromServices] Presenter presenter,
        [FromRoute][Required] GetIssueRequest request)
    {
        useCase.OutputPort = presenter;

        GetIssueInput input = new(request.IssueId);

        await useCase.Execute(input);

        return presenter.ViewModel!;
    }
}
