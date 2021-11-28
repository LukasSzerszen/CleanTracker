using Domain;
using Domain.Builders;
using Domain.ValueObjects;
using System;
using System.Collections.ObjectModel;

namespace Infrastructure.Repositories;

public class IssueTrackerContextFake
{
    public Collection<Sprint> Sprints { get; } = new Collection<Sprint>();
    public Collection<Issue> Issues { get; } = new Collection<Issue>();

    public IssueTrackerContextFake()
    {
        var title1 = IssueTitle.Build("issue1").Value;
        var title2 = IssueTitle.Build("issue2").Value;

        var description1 = IssueDescription.Build("description1").Value;
        var description2 = IssueDescription.Build("description2").Value;

        var points1 = IssuePoints.Build(1).Value;
        var points2 = IssuePoints.Build(1).Value;

        var firstname1 = FirstName.Build("John").Value;

        var lastname2 = LastName.Build("Doe").Value;

        var user1 = new UserBuilder(firstname1, lastname2).Build();

        Issue issue1 = new IssueBuilder(title1).WithPoints(points1).WithDescription(description1).Build();

        Issue issue2 = new IssueBuilder(title2).WithPoints(points2).WithDescription(description2).WithAsignee(user1).Build();

        Issues.Add(issue1);
        Issues.Add(issue2);

        issue2.Assign(user1);

        Sprint sprint = new(
             TrackerId.Build(Guid.NewGuid()).Value
            );

        sprint.Issues.Add(issue1.Id, issue1);
        sprint.Issues.Add(issue2.Id, issue2);

        Sprints.Add(sprint);
    }
}
