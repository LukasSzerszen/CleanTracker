using Application.UseCases.AddSprint;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Modules.Common.FeatureFlags;

namespace WebApi.V1.Sprint.AddSprint;

[FeatureGate(Features.AddSprintUseCase)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public sealed class SprintController : ControllerBase
{

    [HttpPost("addsprint")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> AddSprint([FromServices] IAddSprintUseCase useCase,
        [FromServices] Presenter presenter,
        [FromBody][Required] AddSprintRequest request)
    {
        useCase.OutputPort = presenter;

        AddSprintInput input = new(request.StartDate, request.EndDate);

        await useCase.Execute(input);

        return presenter.ViewModel!;
    }
}
