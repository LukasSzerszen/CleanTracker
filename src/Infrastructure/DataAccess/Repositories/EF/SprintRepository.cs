using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories.EF;
public class SprintRepository : ISprintRepository
{
    public readonly IssueTrackerContext _context;
    public SprintRepository(IssueTrackerContext context)
    {
        _context = context;
    }

    public async Task Add(Sprint sprint)
    {
        await _context.Sprints.AddAsync(sprint);
        await _context.SaveChangesAsync();
    }

    public Task Delete(TrackerId sprintId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Sprint?> GetSprint(TrackerId sprintId)
    {
        var sprint = await _context.Sprints.FindAsync(sprintId);
        return sprint;
    }

    public async Task Update(Sprint sprint)
    {
        Sprint? updatedSprint = await _context.Sprints.FindAsync(sprint.Id);

        if (updatedSprint == null)
        {
            return;
        }

        foreach (Issue issue in sprint.Issues)
        {
            Issue? updatedIssue = await _context.Issues.FindAsync(issue.IssueId);
            if (updatedIssue == null)
            {
                continue;
            }
            updatedIssue.UpdateSprint(issue.SprintId);
            _context.Entry(updatedIssue).Property(i => i.SprintId).IsModified = true;
        }
        await _context.SaveChangesAsync();

    }
}
