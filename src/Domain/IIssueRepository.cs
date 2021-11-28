using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IIssueRepository
{
    Task<Issue> Get(TrackerId issueId);
    Task Add(Issue issue);
    Task Update(TrackerId issueId, Issue issue);
    Task Delete(TrackerId issueId);
}
