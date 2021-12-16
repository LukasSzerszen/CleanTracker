using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.DataAccess.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System;
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
            .AddAsync(issue)
            .ConfigureAwait(false);
    }

    public async Task Delete(TrackerId issueId)
    {
        await _context.Database
            .ExecuteSqlRawAsync("DELETE FROM Issue WHERE IssueId=@p0", issueId.Id);
    }

    public async Task<Issue> Get(TrackerId issueId)
    {
        return await _context.Issues
            .FindAsync(issueId)
            .ConfigureAwait(false);
    }

    public async Task Update(Issue issue)
    {
        await this._context.AddAsync(issue).ConfigureAwait(false); 
    }
}
