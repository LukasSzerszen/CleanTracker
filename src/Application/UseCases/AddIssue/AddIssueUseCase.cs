using Application.UseCases.AddIssue;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase;

public class AddIssueUseCase : IAddIssueUseCase
{
    private readonly IIssueRepository _issueRepository;
    private IOutputPort _outputPort;
    private readonly IIssueFactory _issueFactory;

    public AddIssueUseCase(IIssueRepository issueRepository, IIssueFactory issueFactory)
    {
        _issueRepository = issueRepository;
        _issueFactory = issueFactory;
        _outputPort = new AddIssuePresenter();
    }
    public Task Execute(string issuetitle) => AddIssue(issuetitle);

    private async Task AddIssue(string issueTitle)
    {
        var title = IssueTitle.Build(issueTitle).Value;
        Issue issue = new IssueBuilder(title).Build();
        await _issueRepository.Add(issue).ConfigureAwait(false);
        _outputPort?.Ok(issue);
    }

    public void SetOutputPort(IOutputPort output)
    {
        _outputPort = output;
    }
}
