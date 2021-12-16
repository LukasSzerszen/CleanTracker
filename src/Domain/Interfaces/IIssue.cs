using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IIssue
{
    public TrackerId IssueId { get; }
    public IssueTitle Title { get; }
    public IssueDescription? Description { get; }
    public IssueProgressStatus Status { get; }
    public void UpdateDescription(IssueDescription description);
    public void UpdateProgress(IssueProgressStatus status);
}
