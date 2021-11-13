using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIssueRepository
    {
        Task<IIssue> Get(TrackerId issueId);
        Task Add(Issue issue);
        Task Update(TrackerId issueId, Issue issue);
        Task Delete(TrackerId issueId);
    }
}
