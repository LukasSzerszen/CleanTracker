using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class SprintRepositoryFake : ISprintRepository
    {
        private readonly IssueTrackerContextFake _context;
        public SprintRepositoryFake(IssueTrackerContextFake context) => _context = context;

        public Task Add(TrackerId sprintId)
        {
            throw new NotImplementedException();
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

        public async Task<ISprint> GetSprint(TrackerId sprintId)
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
    }
}
