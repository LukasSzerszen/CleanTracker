using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.UpdateIssue;

public class UpdateIssueUseCase : IUpdateIssueUseCase
{
    public Notification _notification { get; set; }
    public IUpdateIssueOutputPort OutputPort { get; set; }
    private readonly IIssueRepository _issueRepository;
    public UpdateIssueUseCase(Notification notification, IIssueRepository issueRepository)
    {
        _notification = notification;
        _issueRepository = issueRepository;
        OutputPort = new UpdateIssuePresenter();

    }

    public async Task Execute(UpdateIssueInput input)
    {
        TrackerId issueId = TrackerId.Build(input.IssueId).Value;
        IssueTitle? issueTitle = null;
        IssueDescription? issueDescription = null;
        IssuePoints? issuePoints = null;
        TrackerId? assignedTo = null;
        IssueProgressStatus? issueProgressStatus = null;
        if (input.Title != null)
        {
             Result<IssueTitle> result = IssueTitle.Build(input.Title);
            _notification.Add(result.Notifcation);
            issueTitle = result.Value;

        }
        if (input.Description != null)
        {
            Result<IssueDescription> result = IssueDescription.Build(input.Description);
            _notification.Add(result.Notifcation);
            issueDescription = result.Value;
        }
        if (input.Points != null)
        {
             Result<IssuePoints> result = IssuePoints.Build(input.Points.Value);
            _notification.Add(result.Notifcation);
            issuePoints = result.Value;
        }
        if (input.AssignedTo != null)
        {
            Result<TrackerId> result = TrackerId.Build(input.AssignedTo.Value);
            _notification.Add(result.Notifcation);
            assignedTo = result.Value;
        }
        if (input.Status != null)
        {
            try
            {
                Enum.TryParse(input.Status, out IssueProgressStatus statusResult);
                issueProgressStatus = statusResult;
            }
            catch (ArgumentException e)
            {
                _notification.Add(nameof(input.Status), $"Illegal status: {e.Message}");
            }
        }

        if (_notification.isInvalid)
        {
            OutputPort.BadRequest();
        }

        await _issueRepository.Update(issueId, issueTitle,issueDescription, issuePoints, assignedTo, issueProgressStatus);

        OutputPort.Ok();
    }
}

