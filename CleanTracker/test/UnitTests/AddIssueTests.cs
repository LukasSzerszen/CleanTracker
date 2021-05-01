using Application;
using System;
using Xunit;

namespace test
{
    public class AddIssueTests
    {
      [Fact]

      public void AddIssue_creates_issue()
        {
            IssueTracker issueTracker = new IssueTracker();
            bool result = issueTracker.addIssue("1", "I am an issue");
            Assert.True(result);
        }


    }
}
