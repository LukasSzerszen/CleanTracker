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
        public async Task Execute(GetIssueInput input)
        {
            input.Validate(_notification);
            if (_notification.isInvalid)
            {
                this.OutputPort.BadRequest();
                return;
            }
            var trackerId = TrackerId.Build(input.IssueId).Value;
            var issue = await _issueRepository.Get(trackerId);
            OutputPort?.Ok(issue);
        }
    }
}
