using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;


namespace Infrastructure.DataAccess.Factories
{
    public sealed class IssueFactory : IIssueFactory
    {
        public Issue NewIssue(IssueTitle issueTitle) => new Issue(issueTitle);
    }
}
