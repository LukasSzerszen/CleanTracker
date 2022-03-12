using Application.UseCases.UpdateIssue;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.V1.UpdateIssue;

public class Presenter : IUpdateIssueOutputPort
{
    private Notification _notification { get; set; }
    public IActionResult? ViewModel { get; private set; }
    public Presenter(Notification notification) => _notification = notification;
    public void BadRequest()
    {
        ValidationProblemDetails validationProblemDetails = new(_notification.ModelState);
        this.ViewModel = new BadRequestObjectResult(validationProblemDetails);
    }

    public void NotFound()
    {
        ValidationProblemDetails validationProblemDetails = new(_notification.ModelState);
        this.ViewModel = new NotFoundObjectResult(validationProblemDetails);
    }

    public void Ok()
    {
        this.ViewModel = new OkResult();
    }
}
