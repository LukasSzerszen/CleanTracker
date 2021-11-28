using Domain.Interfaces;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain;

public interface ISprintRepository
{
    Task<ISprint> GetSprint(TrackerId sprintId);
    Task Add(Sprint sprint);
    Task Update(TrackerId id, Sprint sprint);
    Task Delete(TrackerId sprintId);
}
