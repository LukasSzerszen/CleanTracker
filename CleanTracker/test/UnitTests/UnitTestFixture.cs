using CleanTracker;

namespace UnitTests
{
    public class UnitTestFixture
    {
        public IssueTracker issueTracker { get; private set; }
        public UnitTestFixture()
        {
            issueTracker = new IssueTracker();
            issueTracker.AddIssue(1, "I am an issue");
        }
    }
}
