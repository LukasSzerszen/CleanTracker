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

    public Task Add(TrackerId sprintId)
    {
        throw new System.NotImplementedException();
    }

    public Task Delete(TrackerId sprintId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<ISprint?> GetSprint(TrackerId sprintId)
    {
        var sprint = await _context.Sprints.FindAsync(sprintId);
        return sprint;
    }

    public Task Update(TrackerId id, Sprint sprint)
    {
        throw new System.NotImplementedException();
    }
}
