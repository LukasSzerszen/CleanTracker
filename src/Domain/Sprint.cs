using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain
{
    public class Sprint : ISprint
    {
        public TrackerId Id { get; }

        public TrackerDate StartDate { get; set; }

        public TrackerDate EndDate { get; set; }

        public IssueCollection Issues { get; } = new IssueCollection();

        public Sprint(TrackerId id)
        {
            Id = id;
        }
        public Sprint(TrackerId id, TrackerDate startDate, TrackerDate endDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int TotalPoints() => Issues.GetTotalPoints();
    }
}
