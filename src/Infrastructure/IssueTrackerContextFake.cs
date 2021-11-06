using Domain;
using Domain.ValueObjects;
using System;
using System.Collections.ObjectModel;

namespace Infrastructure.Repositories
{
    public class IssueTrackerContextFake 
    {
        public Collection<Sprint> Sprints { get; } = new Collection<Sprint>();
        public Collection<Issue> Issues { get; } = new Collection<Issue>();

        public IssueTrackerContextFake()
        {
            Issue issue1 = new (
                new TrackerId(Guid.NewGuid()),
                new IssueDescription("issue1")
                );
            Issue issue2 = new (
                new TrackerId(Guid.NewGuid()),
                new IssueDescription("issue2")
             );

            Issues.Add(issue1);
            Issues.Add(issue2);

            User user1 = new (
                new TrackerId(Guid.NewGuid()),
                new FirstName("Peter"),
                new LastName("Parker")
                );

            issue2.Assign(user1);
            issue2.UpdatePoints(new IssuePoints(2));

            Sprint sprint = new (
                 new TrackerId(Guid.NewGuid())
                );

            sprint.Issues.Add(issue1.Id, issue1);
            sprint.Issues.Add(issue2.Id, issue2);

            Sprints.Add(sprint);
        }
    }
}
