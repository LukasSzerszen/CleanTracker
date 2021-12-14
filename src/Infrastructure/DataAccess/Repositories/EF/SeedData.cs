using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using static Domain.Issue;
using static Domain.User;

namespace Infrastructure.DataAccess.Repositories.EF;

public sealed class SeedData
{
    public readonly static TrackerId IssueId1 = TrackerId.Build(new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890")).Value;
    public readonly static TrackerId IssueId2 = TrackerId.Build(new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298")).Value;
    public readonly static IssueTitle IssueTitle1 = IssueTitle.Build("issue1").Value;
    public readonly static IssueTitle IssueTitle2 = IssueTitle.Build("issue2").Value;
    public readonly static IssueDescription Description1 = IssueDescription.Build("description1").Value;
    public readonly static IssueDescription Description2 = IssueDescription.Build("description2").Value;
    public readonly static IssuePoints Points1 = IssuePoints.Build(1).Value;
    public readonly static IssuePoints Points2 = IssuePoints.Build(2).Value;
    public readonly static FirstName Firstname1 = FirstName.Build("John").Value;
    public readonly static LastName Lastname1 = LastName.Build("Doe").Value;

    public static void Seed(ModelBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var user1 = UserBuilderFactory.Create(Firstname1, Lastname1).Build();

        Issue issue1 = IssueBuilderFactory.Create(IssueId1, IssueTitle1).WithPoints(Points1).WithDescription(Description1).Build();

        Issue issue2 = IssueBuilderFactory.Create(IssueId2, IssueTitle2).WithPoints(Points2).WithDescription(Description2).WithAsignee(user1).Build();

        builder.Entity<Issue>().HasData(issue1, issue2);
    }
}
