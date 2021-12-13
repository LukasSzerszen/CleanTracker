using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;

using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class IssueRepository : IIssueRepository
{
    public Task Add(Issue issue)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TrackerId issueId)
    {
        throw new NotImplementedException();
    }

    public Task<Issue> Get(TrackerId issueId)
    {
        throw new NotImplementedException();
    }

    public Task Update(TrackerId issueId, Issue issue)
    {
        throw new NotImplementedException();
    }
}
