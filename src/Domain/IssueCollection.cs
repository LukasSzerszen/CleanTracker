using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Domain;

public class IssueCollection : Dictionary<TrackerId, Issue>
{

    public Dictionary<TrackerId, Issue> FilterByStatus(IssueProgressStatus status) => this.Where(kvp => kvp.Value.Status == status).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    public double CalculateUserKPI(IUser user) => this.Where(kvp => kvp.Value.AssignedTo == user.UserId).Where(kvp => kvp.Value.Status == IssueProgressStatus.Done).Average(kvp => kvp.Value.Points.Points);
}
