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

    public async Task<Issue> Get(TrackerId issueId)
    {
        return await _context.Issues
            .FindAsync(issueId);
    }

    public async Task Update(Issue issue)
    {
        var issueToUpdate = await _context.FindAsync<Issue>(issue.IssueId);

        if(issueToUpdate == null)
        {
            return;
        }
        issueToUpdate.UpdatePoints(issue.Points);
        issueToUpdate.UpdateProgress(issue.Status);
        issueToUpdate.UpdateDescription(issue.Description);
        await _context.SaveChangesAsync();
    }
}
