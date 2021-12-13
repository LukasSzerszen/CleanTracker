using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.MoveIssue;

public class MoveIssueUseCase : IMoveIssueUseCase
{
    private readonly IIssueRepository _issueRepository;
    private IOutputPort _outputPort;

    public MoveIssueUseCase(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
        _outputPort = new MoveIssuePresenter();
    }

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
    }


    public async Task Execute(Guid issueId, IssueProgressStatus issueProgressStauts)
    {
        var id = TrackerId.Build(issueId).Value;
        await this.MoveIssue(id, issueProgressStauts);
        return;
    }

    private async Task MoveIssue(TrackerId issueId, IssueProgressStatus issueProgressStatus)
    {
        var issue = await _issueRepository.Get(issueId);
        issue.UpdateProgress(issueProgressStatus);
        _outputPort.Ok();
        return;
    }
}
