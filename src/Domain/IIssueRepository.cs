using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IIssueRepository
{
    Task<Issue?> Get(TrackerId issueId);
    Task Add(Issue issue);
    Task Update(TrackerId issueId,
        IssueTitle? title,
        IssueDescription? description,
        IssuePoints? points,
        TrackerId? assignedTo,
        IssueProgressStatus? status);
    Task Delete(TrackerId issueId);
}
