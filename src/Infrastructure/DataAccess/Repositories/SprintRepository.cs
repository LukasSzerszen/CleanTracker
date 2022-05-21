using System;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Infrastructure;

public class SprintRepository : ISprintRepository
{

    public Task Add(Domain.Sprint sprint)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TrackerId sprintId)
    {
        throw new NotImplementedException();
    }

    public Task<Sprint?> GetSprint(TrackerId sprintId)
    {
        throw new NotImplementedException();
    }

    public Task Update(TrackerId id, Domain.Sprint sprint)
    {
        throw new NotImplementedException();
    }
}
