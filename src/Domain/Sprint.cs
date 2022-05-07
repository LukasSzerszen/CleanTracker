using Domain.Interfaces;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain;

public class Sprint : ISprint
{
    public TrackerId Id { get; }

    public TrackerDate StartDate { get; set; }

    public TrackerDate EndDate { get; set; }

    public List<Issue> Issues { get; } = new();
    public Sprint(TrackerId id, TrackerDate startDate, TrackerDate endDate)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
    }
}
