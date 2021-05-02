﻿using System;
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

        public Issue getIssue(int id)
        {
            return issues[id];
        }

        public bool deleteIssue(int id)
        {
            return issues.Remove(id);
        }

        public bool UpdateIssue(int v, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}
