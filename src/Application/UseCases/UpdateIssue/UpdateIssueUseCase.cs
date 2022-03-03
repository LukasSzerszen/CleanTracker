using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;
using static Domain.Issue;

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

    public async Task Execute(UpdateIssueRequest input)
    {
        UpdateIssueInput updateIssueInput = new UpdateIssueInput();
        TrackerId issueId = TrackerId.Build(input.IssueId).Value;
        Result<IssueTitle>? issueTitle = null;
        Result<IssueDescription>? issueDescription = null;
        Result<IssuePoints>? issuePoints = null;
        Result<TrackerId>? assignedTo = null;
        if (input.Title != null)
        {
            issueTitle = IssueTitle.Build(input.Title);
            _notification.Add(issueTitle.Notifcation);
            updateIssueInput.Title = issueTitle.Value;
            
        }
        if(input.Description != null)
        {
            issueDescription = IssueDescription.Build(input.Description);
            _notification.Add(issueDescription.Notifcation);
            updateIssueInput.Description = issueDescription.Value;
        }
        if(input.Points != null)
        {
            issuePoints = IssuePoints.Build(input.Points.Value);
            _notification.Add(issuePoints.Notifcation);
            updateIssueInput.Points = issuePoints.Value;
        }
        if(input.AssignedTo != null)
        {
            assignedTo = TrackerId.Build(input.AssignedTo.Value);
            _notification.Add(assignedTo.Notifcation);
            updateIssueInput.AssignedTo = assignedTo.Value;
        }
        if(input.Status != null)
        {

            try
            {
                Enum.TryParse(input.Status, out IssueProgressStatus statusResult);
                updateIssueInput.Status = statusResult;
                
            }
            catch(ArgumentException e)
            {
                _notification.Add(nameof(input.Status), $"Illegal status: {e.Message}");
            }
        }

        if (_notification.isInvalid)
        {
            OutputPort.BadRequest();
        }

        await _issueRepository.Update(updateIssueInput);

        OutputPort.Ok();
    }
}

