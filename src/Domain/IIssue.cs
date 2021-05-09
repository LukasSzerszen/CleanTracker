using Domain.ValueObjects;

namespace Domain
{
    public interface IIssue
    {
        public IssueId Id { get; }
        public IssueDescription Description { get; }
        public IssuePoints Points { get; }
        public string AssignedTo { get; }
        public IssueProgressStatus Status { get; }
    }
}
