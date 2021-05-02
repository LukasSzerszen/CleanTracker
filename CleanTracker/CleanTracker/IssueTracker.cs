using System;
using System.Collections;
using System.Collections.Generic;

namespace CleanTracker
{
    public class IssueTracker
    {
        private IDictionary<int,Issue> issues { get; set; }

        public IssueTracker()
        {
            issues = new Dictionary<int,Issue>();
        }

        public void addIssue(int id, string description)
        {
            Issue issue = new Issue(id, description);
            issues.Add(id, issue);
        }

        public IEnumerable<Issue> getIssues()
        {
            return issues.Values;
        }
    }
}
