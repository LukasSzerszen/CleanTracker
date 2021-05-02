using System;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public class IssueTracker
    {
        private IList issues { get; set; }

        public IssueTracker()
        {
            issues = new List<Issue>();
        }

        public bool addIssue(string id, string description)
        {
            return false;
        }
    }
}
