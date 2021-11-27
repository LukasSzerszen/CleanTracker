using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IIssueFactory
{
    Issue NewIssue(IssueTitle issueTitle);
}
