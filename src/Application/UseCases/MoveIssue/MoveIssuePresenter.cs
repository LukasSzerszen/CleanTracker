using Domain;
using Domain.Interfaces;
using System;

namespace Application.UseCases.MoveIssue;

public sealed class MoveIssuePresenter : IOutputPort
{
    public bool OkOutput { get; private set; }
    public bool InvalidOutput { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public void Invalid() => this.InvalidOutput = true;
    public void NotFound() => this.NotFoundOutput = true;
    public void Ok() => this.OkOutput = true;

}
