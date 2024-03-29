﻿using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Interfaces;

public interface ISprint
{
    public TrackerId Id { get; }

    public TrackerDate StartDate { get; }

    public TrackerDate EndDate { get; }

    public IReadOnlyCollection<Issue> Issues { get; }

    void AddIssue(Issue issue);
}
