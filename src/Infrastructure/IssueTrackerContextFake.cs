using Domain;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IssueTrackerContextFake 
    {
        public Collection<Sprint> Sprints { get; } = new Collection<Sprint>();

        public IssueTrackerContextFake()
        {
            Issue issue1 = new Issue(
                new TrackerId(Guid.NewGuid()),
                new IssueDescription("issue1")
                );
            Issue issue2 = new Issue(
                new TrackerId(Guid.NewGuid()),
                new IssueDescription("issue2")
             );
            User user1 = new User(
                new TrackerId(Guid.NewGuid()),
                new FirstName("Peter"),
                new LastName("Parker")
                );
            User user2 = new User(
                new TrackerId(Guid.NewGuid()),
                new FirstName("Eddie"),
                new LastName("Brock")
                );

            issue2.Assign(user1);
            issue2.UpdatePoints(new IssuePoints(2));

            Sprint sprint = new Sprint(
                 new TrackerId(Guid.NewGuid())
                );

            sprint.Issues.Add(issue1.Id, issue1);
            sprint.Issues.Add(issue2.Id, issue2);
        }
    }
}
