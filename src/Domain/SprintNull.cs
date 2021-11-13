using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SprintNull : ISprint
    {
        public static SprintNull Instance { get; } = new SprintNull();
        public TrackerId Id => new TrackerId(Guid.Empty);

        public TrackerDate StartDate { get => new TrackerDate(DateTime.Now); }
        public TrackerDate EndDate { get => new TrackerDate(DateTime.Now); }

        public IssueCollection Issues => new IssueCollection();

        public int TotalPoints()
        {
            return 0;
        }
    }
}
