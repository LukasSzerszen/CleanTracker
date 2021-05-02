using CleanTracker;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace test
{
    public class AddIssueTests
    {
        [Fact]

        public void AddIssue_creates_issue()
        {
            IssueTracker issueTracker = new IssueTracker();
            issueTracker.addIssue(1, "I am an issue");
            List<Issue> issues = issueTracker.getIssues().ToList();
            int length = issues.Count();
            Assert.NotEmpty(issues);
        }

        [Fact]

        public void GetIssues_returns_all_issues()
        {
            IssueTracker issueTracker = new IssueTracker();
            issueTracker.addIssue(1, "I am an issue");
            List<Issue> issues = issueTracker.getIssues().ToList();
            Assert.Collection(issues,
                issue =>
                {
                    Assert.Equal("I am an issue", issue.Description);
                    Assert.Equal(1, issue.Id);
                });

        }

        [Fact]

        public void GetIssue_returns_issue()
        {
            IssueTracker issueTracker = new IssueTracker();
            issueTracker.addIssue(1, "I am an issue");
            Issue issue = issueTracker.getIssue(1);
            Assert.Equal(1, issue.Id);
            Assert.Equal("I am an issue", issue.Description);
        }

        [Fact]

        public void DeleteIssue_deletes_issue()
        {
            IssueTracker issueTracker = new IssueTracker();
            issueTracker.addIssue(1, "I am an issue");
            bool result = issueTracker.deleteIssue(1);
            Assert.True(result);
        }

        [Fact]

        public void DeleteIssue_does_not_delete_non_exisiting_issue()
        {
            IssueTracker issueTracker = new IssueTracker();
            bool result = issueTracker.deleteIssue(1);
            Assert.False(result);
        }
    }
}
