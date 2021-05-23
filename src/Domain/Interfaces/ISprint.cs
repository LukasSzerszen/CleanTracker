using Domain.ValueObjects;

namespace Domain.Interfaces
{
    public interface ISprint
    {
        public TrackerId Id { get; }

        public TrackerDate StartDate { get; set; }

        public TrackerDate EndDate { get; set; }

        public IssueCollection Issues { get; }

        public int TotalPoints();
    }
}
