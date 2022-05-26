using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SprintRepositoryFake : ISprintRepository
    {
        private readonly IssueTrackerContextFake _context;
        public SprintRepositoryFake(IssueTrackerContextFake context) => _context = context;

        public Task Add(Sprint sprint)
        {
            _context.Sprints.Add(sprint);
            return Task.CompletedTask;
        }

        public async Task Delete(TrackerId sprintId)
        {
            Sprint? sprint = _context.Sprints.SingleOrDefault(sprint => sprint.Id.Equals(sprintId));

            if (sprint == null)
            {
                return;
            }

            _context.Sprints.Remove(sprint);

            await Task.CompletedTask.ConfigureAwait(false);
        }

        public async Task<Sprint?> GetSprint(TrackerId sprintId)
        {
            Sprint? sprint = _context.Sprints.SingleOrDefault(sprint => sprint.Id.Equals(sprintId));


            return await Task.FromResult(sprint).ConfigureAwait(false);

        }

        public async Task Update(TrackerId sprintId, Sprint sprint)
        {
            Sprint? oldSprint = _context.Sprints.SingleOrDefault(sprint => sprint.Id.Equals(sprintId));

            if (oldSprint != null)
            {
                _context.Sprints.Remove(oldSprint);
                _context.Sprints.Add(sprint);
            }

            await Task.CompletedTask.ConfigureAwait(false);
        }

        public Task Update(Sprint sprint)
        {
            throw new NotImplementedException();
        }
    }
}
