using System;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain
{
    public class Issue : IIssue, IAssignable
    {
        public TrackerId Id { get; }

        public IssueTitle Title { get; }

        public IssueDescription Description { get; set; }

        public IssuePoints Points { get; set; }

        public IUser AssignedTo { get; set; }

        public IssueProgressStatus Status { get; set; }

        public Issue(IssueTitle title)
        {
            Id = new TrackerId(Guid.NewGuid());
            Title = title;
        }
        public Issue(TrackerId id, IssueDescription description)
        {
            Id = id;
            Description = description;
        }

        public Issue(TrackerId id, IssueDescription description, IssuePoints points, IUser assignedTo)
        {
            Id = id;
            Description = description;
            Points = points;
            AssignedTo = assignedTo;
            Status = IssueProgressStatus.NotStarted;
        }

        public void UpdatePoints(IssuePoints points) => Points = points;

        public void UpdateDescription(IssueDescription description) => Description = description;

        public void Assign(IUser assignee) => AssignedTo = assignee;

        public void UpdateProgress(IssueProgressStatus status) => Status = status;
    }
}
