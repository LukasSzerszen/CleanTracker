using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.DataAccess.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class IssueRepository : IIssueRepository
{
    public readonly IssueTrackerContext _context;
    public IssueRepository(IssueTrackerContext context)
    {
        _context = context;
    }
    public async Task Add(Issue issue)
    {
        await _context.Issues
            .AddAsync(issue);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(TrackerId issueId)
    {
        await _context.Database
            .ExecuteSqlRawAsync("DELETE FROM Issue WHERE IssueId=@p0", issueId.Id);
        await _context.SaveChangesAsync();
    }

    public async Task<Issue?> Get(TrackerId issueId)
    {
        return await _context.Issues.FirstOrDefaultAsync(x => x.IssueId == issueId);
    }

    public async Task Update(TrackerId issueId, 
        IssueTitle? title, 
        IssueDescription? description, 
        IssuePoints? points, 
        TrackerId? assignedTo, 
        IssueProgressStatus? status)
    {
        Issue? issue = await _context.FindAsync<Issue>(issueId);

        if (issue == null)
        {
            return;
        }
        _context.Attach(issue);
        if (title != null)
        {
            issue.UpdateTitle(title.Value);
            _context.Entry(issue).Property(i => i.Title).IsModified = true;
        }
        issue.UpdatePoints(points);
        issue.UpdateProgress(status);
        issue.UpdateDescription(description);
        _context.Entry(issue).Property(i => i.Points).IsModified = true;
        _context.Entry(issue).Property(i => i.Status).IsModified = true;
        _context.Entry(issue).Property(i => i.Description).IsModified = true;
        await _context.SaveChangesAsync();
    }
}
