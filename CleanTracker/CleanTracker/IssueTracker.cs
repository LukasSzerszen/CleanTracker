using System;
using System.Collections;
using System.Collections.Generic;

namespace CleanTracker
{
    public class IssueTracker
    {
        private IList issues { get; set; }

        public IssueTracker()
        {
            issues = new List<Issue>();
        }

        public int addIssue(string id, string description)
        {
            Issue issue = new Issue(id, description);
            int result = issues.Add(issue);
            return result;
        }

        public void getAllIssues()
        {
            throw new NotImplementedException();
        }
    }
}
