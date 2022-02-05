using Domain;

namespace WebApi.V1.GetIssue;

public sealed class GetIssueResponse
{
    public Guid? TrackerId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Points { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Status { get; set; }

    public GetIssueResponse(Issue? issue)
    {
        if (issue != null)
        {
            TrackerId = issue.IssueId.Id;
            Title = issue.Title.Title;
            Description = issue.Description.HasValue ? issue.Description.Value.Description : null;
            Points = issue.Points.HasValue ? issue.Points.Value.Points : null;
            AssignedTo = issue.AssignedTo.HasValue ? issue.AssignedTo.Value.Id : null;
            Status = issue.Status.ToString();
        }
    }
}
