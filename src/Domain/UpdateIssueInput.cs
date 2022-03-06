using Domain.ValueObjects;

namespace Domain;

public sealed class UpdateIssueInput
{
    public TrackerId IssueId { get; set; }
    public IssueTitle? Title { get; set; }
    public IssueDescription? Description { get; set; }
    public IssuePoints? Points { get; set; }
    public TrackerId? AssignedTo { get; set; }
    public IssueProgressStatus? Status { get; set; }
}
