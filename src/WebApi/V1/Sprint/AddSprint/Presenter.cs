using Application.UseCases.AddSprint;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.V1.Sprint.AddSprint;

public class Presenter : IAddSprintOutputPort
{
    private Notification _notification { get; set; }
    public IActionResult? ViewModel { get; private set; }
    public Presenter(Notification notification) => _notification = notification;
    public void BadRequest()
    {
        ValidationProblemDetails validationProblemDetails = new(_notification.ModelState);
        ViewModel = new BadRequestObjectResult(validationProblemDetails);
    }

    public void Ok()
    {
        ViewModel = new OkResult();
    }
}
