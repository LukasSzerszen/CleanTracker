using System;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain;

public class Issue : IIssue, IAssignable
{

    public TrackerId Id { get; }

    public IssueTitle Title { get; }

    public IssueDescription Description { get; set; }

    public IssuePoints Points { get; set; }

    public IUser AssignedTo { get; set; }

    public IssueProgressStatus Status { get; set; }

    public Issue(TrackerId id, IssueTitle title)
    {
        Id = id;
        Title = title;
    }

    public void UpdatePoints(IssuePoints points) => Points = points;

    public void UpdateDescription(IssueDescription description) => Description = description;

    public void Assign(IUser assignee) => AssignedTo = assignee;

    public void UpdateProgress(IssueProgressStatus status) => Status = status;

    public class IssueBuilder : IIssueBuilder
    {
        private Issue Issue;
        public IssueBuilder(TrackerId trackerId, IssueTitle title)
        {
            this.Issue= new Issue(trackerId, title);
           
        }

        public Issue Build()
        {
            var result = this.Issue;
            Issue = null;
            return result;
        }

        public IIssueBuilder WithAsignee(IUser user)
        {
            Issue.AssignedTo = user;
            return this;
        }

        public IIssueBuilder WithDescription(IssueDescription description)
        {
            Issue.Description = description;
            return this;
        }

        public IIssueBuilder WithPoints(IssuePoints points)
        {
            Issue.Points = points;
            return this;
        }
    }

    public static class IssueBuilderFactory
    {
        public static IssueBuilder Create(TrackerId trackerId, IssueTitle title)
        {
            return new IssueBuilder(trackerId, title);
        }
    }

}
