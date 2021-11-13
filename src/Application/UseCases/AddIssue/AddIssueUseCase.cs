using Application.UseCases.AddIssue;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase
{
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
        public Task Execute(string issuetitle ) => AddIssue(new IssueTitle(issuetitle));
           
        private async Task AddIssue(IssueTitle issueTitle)
        {
            Issue issue = _issueFactory.NewIssue(issueTitle);
            await _issueRepository.Add(issue).ConfigureAwait(false);
            _outputPort?.Ok(issue);
        }

        public void SetOutputPort(IOutputPort output)
        {
            _outputPort = output;
        }
    }
}
