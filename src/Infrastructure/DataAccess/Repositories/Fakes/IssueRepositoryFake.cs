using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories.Fakes;

public class IssueRepositoryFake : IIssueRepository
{
    private readonly IssueTrackerContextFake _context;
    public IssueRepositoryFake(IssueTrackerContextFake context) => _context = context;
    public async Task Add(Issue issue)
    {
        _context.Issues.Add(issue);

        await Task.CompletedTask.ConfigureAwait(false);
    }

    public async Task Delete(TrackerId issueId)
    {
        Issue? issue = _context.Issues.SingleOrDefault(issue => issue.IssueId.Equals(issueId));

        if (issue == null)
        {
            return;
        }

        _context.Issues.Remove(issue);

        await Task.CompletedTask.ConfigureAwait(false);
    }

    public async Task<Issue> Get(TrackerId issueId)
    {
        Issue issue = _context.Issues
            .Where(issue => issue.IssueId.Equals(issueId))
            .Select(issue => issue)
            .SingleOrDefault();

        return await Task.FromResult(issue).ConfigureAwait(false);
    }

    public async Task Update(Issue issue)
    {
        Issue? oldIssue = _context.Issues
            .SingleOrDefault(issue => issue.IssueId.Equals(issue.IssueId));

        if (oldIssue != null)
        {
            _context.Issues.Remove(oldIssue);
            _context.Issues.Add(issue);
        }

        await Task.CompletedTask.ConfigureAwait(false);
    }

    public async Task Update(TrackerId issueId, IssueTitle? title, IssueDescription? description, IssuePoints? points, TrackerId? assignedTo, IssueProgressStatus? status)
    {
        Issue? issue = _context.Issues.Where(x => x.IssueId == issueId).FirstOrDefault();
        if (issue == null)
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }
        if (title != null)
        {
            issue!.UpdateTitle(title.Value);
        }

        issue!.UpdateDescription(description);
        issue.UpdatePoints(points);
        issue.UpdateProgress(status);
    }
}
