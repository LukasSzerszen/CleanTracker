using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Domain;

public class IssueCollection : Dictionary<TrackerId, Issue>
{

    public Dictionary<TrackerId, Issue> FilterByStatus(IssueProgressStatus status) => this.Where(kvp => kvp.Value.Status == status).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

}
