using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class SprintRepository : ISprintRepository
    {

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
