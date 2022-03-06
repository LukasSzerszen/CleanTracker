using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IIssueRepository
{
    Task<Issue?> Get(TrackerId issueId);
    Task Add(Issue issue);
    Task Update(UpdateIssueInput input);
    Task Delete(TrackerId issueId);
}
