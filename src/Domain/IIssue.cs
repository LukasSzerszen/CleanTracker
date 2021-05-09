using Domain.ValueObjects;

namespace Domain
{
    public interface IIssue
    {
        public IssueId Id { get; }
        public IssueDescription Description { get; set; }
        public IssuePoints Points { get; set; }
        public string AssignedTo { get; set; }
        public IssueProgressStatus Status { get; set; }
        public void UpdatePoints(IssuePoints points);
        public void UpdateDescription(IssueDescription description);
        public void Assign(string assignee);
        public void UpdateProgress(IssueProgressStatus status);
    }
}
