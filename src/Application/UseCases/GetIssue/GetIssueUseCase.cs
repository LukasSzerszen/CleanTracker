using Application.UseCases.AddIssue;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetIssue
{
    public sealed class GetIssueUseCase : IGetIssueUseCase
    {
        private readonly IIssueRepository _issueRepository;
        private IOutputPort _outputPort;

        public GetIssueUseCase(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
            _outputPort = new GetIssuePresenter();
        }
        public async Task Execute(Guid issueId) => await GetIssue(issueId);
        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }

        private async Task GetIssue(Guid issueId)
        {
            var trackerId = TrackerId.Build(issueId).Value;
            var issue = await _issueRepository.Get(trackerId);
            _outputPort?.Ok(issue);
        }
    }
}
