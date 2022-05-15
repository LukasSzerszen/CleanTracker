using System;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Infrastructure;

public class SprintRepository : ISprintRepository
{

    public Task Add(ISprint sprint)
    {
        throw new NotImplementedException();
    }

    public Task Add(Sprint sprint)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TrackerId sprintId)
    {
        throw new NotImplementedException();
    }

    public Task<ISprint?> GetSprint(TrackerId sprintId)
    {
        throw new NotImplementedException();
    }

    public Task Update(TrackerId id, Sprint sprint)
    {
        throw new NotImplementedException();
    }
}
