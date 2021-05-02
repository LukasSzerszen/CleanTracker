using CleanTracker;
using Xunit;

namespace test
{
    public class AddIssueTests
    {
        [Fact]

        public void AddIssue_creates_issue()
        {
            IssueTracker issueTracker = new IssueTracker();
            int result = issueTracker.addIssue("1", "I am an issue");
            Assert.NotEqual(-1, result);
        }

        [Fact]

        public void GetIssues_returns_all_issues()
        {
            IssueTracker issueTracker = new IssueTracker();
            int result = issueTracker.addIssue("1", "I am an issue");
            issueTracker.getAllIssues();
        }

    }
}
