using Domain.Interfaces;
using Domain.ValueObjects;
using System;

namespace Domain;

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
