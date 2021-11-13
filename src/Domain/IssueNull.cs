using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IssueNull : IIssue
    {
        public static IssueNull Instance { get; } = new IssueNull();

        public TrackerId Id => new TrackerId(Guid.Empty);

        public IssueDescription Description { get; } = new IssueDescription(string.Empty);

        public IssueProgressStatus Status { get; } = IssueProgressStatus.NotStarted;

        public IssueTitle Title { get; } = new IssueTitle(string.Empty);

        public void UpdateDescription(IssueDescription description)
        {
           //Null Pattern
        }

        public void UpdateProgress(IssueProgressStatus status)
        {
           //Null Pattern
        }
    }
}
