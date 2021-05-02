using CleanTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
