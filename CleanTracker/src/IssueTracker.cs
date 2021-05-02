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

        public void AddIssue(int id, string description)
        {
            Issue issue = new Issue(id, description);
            issues.Add(id, issue);
        }

        public IEnumerable<Issue> GetIssues()
        {
            return issues.Values;
        }

        public Issue GetIssue(int id)
        {
            return issues[id];
        }

        public bool DeleteIssue(int id)
        {
            return issues.Remove(id);
        }

        public void UpdateIssue(int id, string newDescription)
        {
            if(issues.TryGetValue(id, out _))
            {
                issues[id].Description = newDescription;
            }
            else
            {
                Issue issue = new Issue(id, newDescription);
                issues.Add(id, issue);
            }

        }
    }
}
