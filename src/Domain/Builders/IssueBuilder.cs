using Domain.ValueObjects;

namespace Domain.Builders;

public class IssueBuilder : IIssueBuilder
{
    private Issue Issue;

    public IssueBuilder(IssueTitle title)
    {
        Issue = new Issue(title);
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

    public Issue Build()
    {
        var result = this.Issue;
        this.Issue = null;
        return result;
    }
}
