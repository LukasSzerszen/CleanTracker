using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteIssue;

public class DeleteIssueUseCase : IDeleteIssueUseCase
{
    private readonly IIssueRepository _issueRepository;
    public IDeleteIssueOutputPort OutputPort { get; set; }
    public Notification Notification;

    public DeleteIssueUseCase(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
        Notification = new Notification();
        OutputPort = new DeleteIssuePresenter();
    }

    public void SetOutputPort(IDeleteIssueOutputPort outputPort)
    {
        OutputPort = outputPort;
    }
    public async Task Execute(DeleteIssueInput input)
    {
        var trackerId = TrackerId.Build(input.IssueId).Value;

        await _issueRepository.Delete(trackerId);

        OutputPort.Ok();
        return;
    }
}
