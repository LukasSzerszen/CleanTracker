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
        var issueId = TrackerId.Build(Guid.NewGuid()).Value;
        var titleResult = IssueTitle.Build(input.Title);
        _notification.Add(titleResult.Notifcation);
        IssueDescription? description = null;
        IssuePoints? points = null;
        TrackerId? assingedTo = null;
        IssueProgressStatus? progressStatus = null;

        if (input.Description != null)
        {
            var result = IssueDescription.Build(input.Description);
            _notification.Add(result.Notifcation);
            description = result.Value;
        }
        if (input.Points != null)
        {
            var result = IssuePoints.Build(input.Points.Value);
            _notification.Add(result.Notifcation);
            points = result.Value;
        }
        if (input.AssignedTo != null)
        {
            var result = TrackerId.Build(input.AssignedTo.Value);
            _notification.Add(result.Notifcation);
            assingedTo = result.Value;
        }
        if (input.Status != null)
        {
            try
            {
                Enum.TryParse<IssueProgressStatus>(input.Status, out IssueProgressStatus statusResult);
                progressStatus = statusResult;
            }
            catch (ArgumentException e)
            {
                _notification.Add(nameof(input.Status), $"Invalid status: {e.Message}");
            }
        }

        if (_notification.isInvalid)
        {
            OutputPort?.BadRequest();
        }

        Issue issue = IssueBuilderFactory.Create(issueId, titleResult.Value)
                .WithDescription(description)
                .WithPoints(points)
                .WithAsignee(assingedTo)
                .WithStatus(progressStatus)
                .Build();

        await _issueRepository.Add(issue).ConfigureAwait(false);
        OutputPort?.Ok(issue);
    }
}
