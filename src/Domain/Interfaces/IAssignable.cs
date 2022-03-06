using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IAssignable
{
    public TrackerId? AssignedTo { get; }
    public IssuePoints? Points { get; }
    public void Assign(TrackerId assignee);
    public void UpdatePoints(IssuePoints? points);

}
