using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IIssueBuilder
{
    public IIssueBuilder WithDescription(IssueDescription? description);
    public IIssueBuilder WithPoints(IssuePoints? points);
    public IIssueBuilder WithAsignee(TrackerId? user);
    public IIssueBuilder WithStatus(IssueProgressStatus? status);
    public IIssueBuilder WithSprint(Sprint? sprint);
    public Issue Build();

}
