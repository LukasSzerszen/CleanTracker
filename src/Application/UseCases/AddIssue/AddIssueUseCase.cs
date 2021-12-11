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
    private IOutputPort _outputPort;

    public AddIssueUseCase(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
        _outputPort = new AddIssuePresenter();
    }
    public async Task Execute(string issuetitle) => await AddIssue(issuetitle);

    private async Task AddIssue(string issueTitle)
    {
        var title = IssueTitle.Build(issueTitle).Value;
        var id = TrackerId.Build(Guid.NewGuid()).Value;
        Issue issue = IssueBuilderFactory.Create(id, title).Build();
        await _issueRepository.Add(issue).ConfigureAwait(false);
        _outputPort?.Ok(issue);
    }

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
}
