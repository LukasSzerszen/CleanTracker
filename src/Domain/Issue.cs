using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain;

public class Issue : IIssue, IAssignable
{
    public TrackerId IssueId { get; }

    public IssueTitle Title { get; private set; }

    public IssueDescription? Description { get; private set; }

    public IssuePoints? Points { get; private set; }

    public TrackerId? AssignedTo { get; private set; }

    public IssueProgressStatus? Status { get; private set; }

    public Issue(TrackerId issueId, IssueTitle title)
    {
        IssueId = issueId;
        Title = title;
        Status = IssueProgressStatus.NotStarted;
    }

    public void UpdatePoints(IssuePoints? points) => Points = points;

    public void UpdateDescription(IssueDescription? description) => Description = description;

    public void Assign(TrackerId assignee) => AssignedTo = assignee;

    public void UpdateProgress(IssueProgressStatus? status) => Status = status;

    public void UpdateTitle(IssueTitle title) => Title = title;

    public class IssueBuilder : IIssueBuilder
    {
        private Issue Issue;
        public IssueBuilder(TrackerId trackerId, IssueTitle title)
        {
            this.Issue = new Issue(trackerId, title);

        }

        public Issue Build()
        {
            var result = this.Issue;
            Issue = null;
            return result;
        }

        public IIssueBuilder WithAsignee(TrackerId? user)
        {
            Issue.AssignedTo = user;
            return this;
        }

        public IIssueBuilder WithDescription(IssueDescription? description)
        {
            Issue.Description = description;
            return this;
        }

        public IIssueBuilder WithPoints(IssuePoints? points)
        {
            Issue.Points = points;
            return this;
        }

        public IIssueBuilder WithStatus(IssueProgressStatus? status)
        {
            Issue.Status = status;
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
