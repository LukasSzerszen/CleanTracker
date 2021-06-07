using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain
{
    public class Sprint : ISprint
    {
        public TrackerId Id { get; }

        public TrackerDate StartDate { get; set; }

        public TrackerDate EndDate { get; set; }

        public IssueCollection Issues {get; set;}

        public int TotalPoints() => Issues.GetTotalPoints();
    }
}
