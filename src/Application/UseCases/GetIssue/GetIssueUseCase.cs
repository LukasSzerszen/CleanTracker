using Application.UseCases.AddIssue;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetIssue
{
    public sealed class GetIssueUseCase : IGetIssueUseCase
    {
        private readonly IIssueRepository _issueRepository;
        private readonly Notification _notification;
        public IGetIssueOutputPort OutputPort { get; set; }

        public GetIssueUseCase(IIssueRepository issueRepository, Notification notification)
        {
            _notification = notification;
            _issueRepository = issueRepository;
            OutputPort = new GetIssuePresenter();
        }
        public async Task Execute(GetIssueInput input) => await GetIssue(input.IssueId);

        private async Task GetIssue(Guid issueId)
        {
            var trackerId = TrackerId.Build(issueId).Value;
            var issue = await _issueRepository.Get(trackerId);
            OutputPort?.Ok(issue);
        }
    }
}
