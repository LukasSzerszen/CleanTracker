using Domain.Interfaces;
using Domain.ValueObjects;
using System;

namespace Domain;

public class SprintNull : ISprint
{
    public static SprintNull Instance { get; } = new SprintNull();
    public TrackerId Id => TrackerId.Build(Guid.NewGuid()).Value;
    public TrackerDate StartDate { get => TrackerDate.Build(DateTime.Now).Value; }
    public TrackerDate EndDate { get => TrackerDate.Build(DateTime.Now).Value; }

    public IssueCollection Issues => new IssueCollection();

    public int TotalPoints()
    {
        return 0;
    }
}
