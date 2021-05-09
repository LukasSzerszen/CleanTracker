using Domain.ValueObjects;
using System;

namespace Domain
{
    public class Issue : IIssue
    {
        public IssueId Id { get; }

        public IssueDescription Description { get; set; }

        public IssuePoints Points { get; set; }

        public string AssignedTo { get; set; }

        public IssueProgressStatus Status { get; set; }

        public Issue(IssueId id, IssueDescription description, IssuePoints points, string assignedTo)
        {
            Id = id;
            Description = description;
            Points = points;
            AssignedTo = assignedTo;
            Status = IssueProgressStatus.NotStarted;
        }

        public void UpdatePoints(IssuePoints points) => Points = points;

        public void UpdateDescription(IssueDescription description) => Description = description;

        public void Assign(string assignee) => AssignedTo = assignee;

        public void UpdateProgress(IssueProgressStatus status) => Status = status; 
    }
}
