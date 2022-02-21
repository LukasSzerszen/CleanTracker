using Application.UseCases.AddIssue;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;
using static Domain.Issue;

namespace Application.UseCases.AddIssueUseCase;

public class AddIssueUseCase : IAddIssueUseCase
{
    private readonly IIssueRepository _issueRepository;
    private readonly Notification _notification;
    public IAddIssueOutputPort OutputPort { get; set; }

    public AddIssueUseCase(IIssueRepository issueRepository, Notification notification)
    {
        _notification = notification;
        _issueRepository = issueRepository;
        OutputPort = new AddIssuePresenter();
    }
    public async Task Execute(AddIssueInput input) => await AddIssue(input);

    private async Task AddIssue(AddIssueInput input)
    {
        Issue issue = IssueBuilderFactory.Create(input.IssueId, input.Title)
                .WithDescription(input.Description)
                .WithPoints(input.Points)
                .WithAsignee(input.AssignedTo)
                .WithStatus(input.Status)
                .Build();
        await _issueRepository.Add(issue).ConfigureAwait(false);
        OutputPort?.Ok(issue);
    }
}
