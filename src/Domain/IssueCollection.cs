using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IssueCollection : Dictionary<IssueId, IIssue>
    {
       
        public IssuePoints GetTotalPoints()
        {
            if(this.Count == 0)
            {
                return new IssuePoints(0);
            }

            IssuePoints sum = new IssuePoints(0);

            return this.Values.Aggregate(sum, (currentIssue, nextIssue) => new IssuePoints(sum.Points + currentIssue.Points));
        }

        public double CalculateKPI()
        {
            return this.Values.Average(issue => issue.Points.Points);
        }

       
    }
}
