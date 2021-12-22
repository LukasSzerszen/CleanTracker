using Application.UseCases.GetIssue;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;
using WebApi.V1.GetIssue;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]

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
