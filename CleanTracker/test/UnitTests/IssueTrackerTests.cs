using CleanTracker;
using System.Collections.Generic;
using System.Linq;
using UnitTests;
using Xunit;

namespace test
{
    public class IssueTrackerTests : IClassFixture<UnitTestFixture>
    {
        UnitTestFixture _unitTestFixture;

        public IssueTrackerTests(UnitTestFixture fixture)
        {
            _unitTestFixture = fixture;
        }

        [Fact]

        public void AddIssue_creates_issue()
        {
            _unitTestFixture.issueTracker.AddIssue(2, "I am an issue");
            List<Issue> issues = _unitTestFixture.issueTracker.GetIssues().ToList();
            int length = issues.Count();
            Assert.Equal(2, length);
        }

        [Fact]

        public void GetIssues_returns_all_issues()
        {
            List<Issue> issues = _unitTestFixture.issueTracker.GetIssues().ToList();
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
            Issue issue = _unitTestFixture.issueTracker.GetIssue(1);
            Assert.Equal(1, issue.Id);
            Assert.Equal("I am an issue", issue.Description);
        }

        [Fact]

        public void DeleteIssue_deletes_issue()
        {

            bool result = _unitTestFixture.issueTracker.DeleteIssue(1);
            Assert.True(result);
        }

        [Fact]

        public void DeleteIssue_does_not_delete_non_exisiting_issue()
        {
            bool result = _unitTestFixture.issueTracker.DeleteIssue(99);
            Assert.False(result);
        }

        [Fact]
        public void UpdateIssue_updates_issue()
        {
            string newDescription = "I am an updated issue";
            _unitTestFixture.issueTracker.UpdateIssue(1, newDescription);
            Assert.Equal(newDescription, _unitTestFixture.issueTracker.GetIssue(1).Description);
        }
    }
}
