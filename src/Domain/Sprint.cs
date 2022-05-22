using Domain.Interfaces;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain;

public class Sprint : ISprint
{
    public TrackerId Id { get; }

    public TrackerDate StartDate { get; private set; }

    public TrackerDate EndDate { get; private set; }

    private readonly List<Issue> _issues = new();
    public IReadOnlyCollection<Issue> Issues => _issues.AsReadOnly();
    private Sprint(TrackerId id, TrackerDate startDate, TrackerDate endDate)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
    }

    public class SprintBuilder : ISprintBuilder
    {
        private Sprint? Sprint;
        public SprintBuilder(TrackerId sprintId, TrackerDate startDate, TrackerDate endDate)
        {
            Sprint = new(sprintId, startDate, endDate);
        }
        public Sprint? Build()
        {
            var result = this.Sprint;
            Sprint = null;
            return result;
        }
    }

    public static class SprintBuilderFactory
    {
        public static SprintBuilder Create(TrackerId sprintId, TrackerDate startDate, TrackerDate endDate)
        {
            return new SprintBuilder(sprintId, startDate, endDate);
        }
    }

    public void AddIssue(Issue issue)
    {
        issue.UpdateSprint(Id);
        _issues.Add(issue);
    }

}
