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
        public Task Add(ISprint sprint)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TrackerId sprintId)
        {
            throw new NotImplementedException();
        }

        public Task<ISprint> GetSprint(TrackerId sprintId)
        {
            throw new NotImplementedException();
        }

        public Task Update(ISprint sprint)
        {
            throw new NotImplementedException();
        }
    }
}
