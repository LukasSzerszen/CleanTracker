using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteIssue;

public class DeleteIssueUseCase : IDeleteIssueUseCase
{
    private readonly IIssueRepository _issueRepository;
    private IOutputPort _outputPort;
    public Notification Notification;

    public DeleteIssueUseCase(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
        Notification = new Notification();
    }

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
    public async Task Execute(Guid issueId)
    {
        var trackerId = TrackerId.Build(issueId);
        await DeleteIssue(trackerId.Value);
        return;
    }

    private async Task DeleteIssue(TrackerId issueId)
    {
        await _issueRepository.Delete(issueId);
        _outputPort.Ok();
        return;
    }

}
