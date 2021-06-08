using Domain.ValueObjects;

namespace Domain.Interfaces
{
    public interface IIssue
    {
        public TrackerId Id { get; }
        public IssueDescription Description { get; set; }
        public IssueProgressStatus Status { get; set; }
        public void UpdateDescription(IssueDescription description);
        public void UpdateProgress(IssueProgressStatus status);
    }
}
