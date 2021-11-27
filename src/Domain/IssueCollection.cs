using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IssueCollection : Dictionary<TrackerId, Issue>
    {

        public int GetTotalPoints()
        {
            if (this.Count == 0)
            {
                return 0;
            }

            IssuePoints sum = new IssuePoints(0);

            return this.Values.Aggregate(sum, (currentIssue, nextIssue) => new IssuePoints(sum.Points + currentIssue.Points)).Points;
        }

        public Dictionary<TrackerId, Issue> FilterByStatus(IssueProgressStatus status) => this.Where(kvp => kvp.Value.Status == status).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        public double CalculateUserKPI(IUser user) => this.Where(kvp => kvp.Value.AssignedTo.Id == user.Id).Where(kvp => kvp.Value.Status == IssueProgressStatus.Done).Average(kvp => kvp.Value.Points.Points);
    }
}
