using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface ISprint
{
    public TrackerId Id { get; }

    public TrackerDate StartDate { get; }

    public TrackerDate EndDate { get; }

    public IssueCollection Issues { get; }

    public int TotalPoints();
}
