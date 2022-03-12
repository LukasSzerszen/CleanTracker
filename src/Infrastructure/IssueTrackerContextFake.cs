using Domain;
using Domain.ValueObjects;
using System;
using System.Collections.ObjectModel;
using static Domain.Issue;
using static Domain.User;

namespace Infrastructure.Repositories;

public class IssueTrackerContextFake
{
    public Collection<Sprint> Sprints { get; } = new Collection<Sprint>();
    public Collection<Issue> Issues { get; } = new Collection<Issue>();

    public IssueTrackerContextFake()
    {
        var issueId1 = TrackerId.Build(new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890")).Value;
        var issueId2 = TrackerId.Build(new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298")).Value;
        var issueId3 = TrackerId.Build(new Guid("cb333ef9-9986-45ef-8872-e3429afb6d3a")).Value;
        var issueId4 = TrackerId.Build(new Guid("9d64104d-e211-44a6-8331-c1134937cd69")).Value;

        var title1 = IssueTitle.Build("issue1").Value;
        var title2 = IssueTitle.Build("issue2").Value;
        var title3 = IssueTitle.Build("issue3").Value;
        var title4 = IssueTitle.Build("issue4").Value;

        var description1 = IssueDescription.Build("description1").Value;
        var description2 = IssueDescription.Build("description2").Value;

        var points1 = IssuePoints.Build(1).Value;
        var points2 = IssuePoints.Build(2).Value;

        var firstname1 = FirstName.Build("John").Value;

        var lastname2 = LastName.Build("Doe").Value;

        var user1 = UserBuilderFactory.Create(firstname1, lastname2).Build();

        Issue issue1 = IssueBuilderFactory.Create(issueId1, title1).WithPoints(points1).WithDescription(description1).Build();

        Issue issue2 = IssueBuilderFactory.Create(issueId2, title2).WithPoints(points2).WithDescription(description2).WithAsignee(user1.UserId).Build();

        Issue issue3 = IssueBuilderFactory.Create(issueId3, title3).Build();

        Issue issue4 = IssueBuilderFactory.Create(issueId4, title4).Build();

        Issues.Add(issue1);
        Issues.Add(issue2);
        Issues.Add(issue3);
        Issues.Add(issue4);

        issue2.Assign(user1.UserId);

        Sprint sprint = new(
             TrackerId.Build(Guid.NewGuid()).Value
            );

        sprint.Issues.Add(issue1.IssueId, issue1);
        sprint.Issues.Add(issue2.IssueId, issue2);

        Sprints.Add(sprint);
    }
}
