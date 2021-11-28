using Domain.ValueObjects;

namespace Domain;

public interface IIssueBuilder
{
    public IIssueBuilder WithDescription(IssueDescription description);
    public IIssueBuilder WithPoints(IssuePoints points);
    public IIssueBuilder WithAsignee(IUser user);
    public Issue Build();

}
