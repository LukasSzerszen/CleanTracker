using Domain.ValueObjects;
using System;

namespace Domain
{
    public class Issue : IIssue
    {
        public IssueId Id { get; set; }

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

        public void UpdatePoints(IssuePoints expectedPoints)
        {
            throw new NotImplementedException();
        }

        public IssuePoints GetPoints()
        {
            throw new NotImplementedException();
        }
    }
}
