﻿using Application.UseCases.AddIssue;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.V1.AddIssue;

public sealed class Presenter : IAddIssueOutputPort
{
    private Notification _notification { get; set; }
    public Presenter(Notification notification) => _notification = notification;

    public IActionResult? ViewModel { get; private set; }

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

    public void Ok(Issue issue)
    {
        var response = new AddIssueResponse(issue);
        this.ViewModel = new OkObjectResult(response);
    }
}
