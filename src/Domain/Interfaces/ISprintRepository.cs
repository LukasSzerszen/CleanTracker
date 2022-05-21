﻿using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface ISprintRepository
{
    Task<Sprint?> GetSprint(TrackerId sprintId);
    Task Add(Sprint sprintId);
    Task Update(TrackerId id, Sprint sprint);
    Task Delete(TrackerId sprintId);
}
