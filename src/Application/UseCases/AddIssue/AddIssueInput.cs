using Domain;
using Domain.ValueObjects;
using System;

namespace Application.UseCases.AddIssue;

public sealed class AddIssueInput
{
    public Notification Notification { get; private set; }
    public TrackerId IssueId { get; private set; }

    public IssueTitle Title { get; private set; }

    public IssueDescription? Description { get; private set; }

    public IssuePoints? Points { get; private set; }

    public TrackerId? AssignedTo { get; private set; }

    public IssueProgressStatus? Status { get; private set; }

    public AddIssueInput(string title, string? description, int? points, Guid? assignedId, string? status)
    {
        Notification = new Notification();
        IssueId = TrackerId.Build(Guid.NewGuid()).Value;
        var titleResult = IssueTitle.Build(title);
        Notification.Add(titleResult.Notifcation);
        Title = titleResult.Value;
        if(description != null)
        {
            var result = IssueDescription.Build(description);
            Notification.Add(result.Notifcation);
            Description = result.Value;
        }
        if(points != null)
        {   
            var result = IssuePoints.Build(points.Value);
            Notification.Add(result.Notifcation);
            Points = result.Value;
        }
        if(assignedId != null)
        {
            var result = TrackerId.Build(assignedId.Value);
            Notification.Add(result.Notifcation);
            AssignedTo = result.Value;
        }
        if(status != null)
        {
            try
            {
                Enum.TryParse<IssueProgressStatus>(status, out IssueProgressStatus statusResult);
                Status = statusResult;
            }
            catch(Exception e)
            {
                Notification.Add(nameof(status), "Invalid status");
            }
        }
    }

    public bool validate()
    {
        return Notification.isValid;
    }

}
