using Domain.Issues;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IIssue
    {
        public IssueId Id { get; }
        public IssueDescription Description { get; }
        public IssuePoints Points { get; }
        public string AssignedTo { get; }
        public IssueProgressStatus Status { get; }
    }
}
