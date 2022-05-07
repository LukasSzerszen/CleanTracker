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
    public readonly static TrackerId IssueId3 = TrackerId.Build(new Guid("d5bf8c94-f7f3-4aaa-85fc-b02efd4a6d89")).Value;
    public readonly static TrackerId SprintId1 = TrackerId.Build(new Guid("76245a54-2a26-4de9-92ab-1ddbbccb6591")).Value;
    public readonly static TrackerId sprintId2 = TrackerId.Build(new Guid("60ea7367-b7ec-48e4-af5d-238acddb3ba6")).Value;
    public readonly static IssueTitle IssueTitle1 = IssueTitle.Build("issue1").Value;
    public readonly static IssueTitle IssueTitle2 = IssueTitle.Build("issue2").Value;
    public readonly static IssueTitle IssueTitle3 = IssueTitle.Build("issue3").Value;
    public readonly static IssueDescription Description1 = IssueDescription.Build("description1").Value;
    public readonly static IssueDescription Description2 = IssueDescription.Build("description2").Value;
    public readonly static IssueDescription Description3 = IssueDescription.Build("description3").Value;
    public readonly static IssuePoints Points1 = IssuePoints.Build(1).Value;
    public readonly static IssuePoints Points2 = IssuePoints.Build(2).Value;
    public readonly static IssuePoints Points3 = IssuePoints.Build(4).Value;
    public readonly static FirstName Firstname1 = FirstName.Build("John").Value;
    public readonly static LastName Lastname1 = LastName.Build("Doe").Value;
    public readonly static TrackerDate Startdate1 = TrackerDate.Build(DateTime.UtcNow).Value;
    public readonly static TrackerDate Enddate1 = TrackerDate.Build(DateTime.UtcNow.AddDays(14)).Value;

    public static void Seed(ModelBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var user1 = UserBuilderFactory.Create(Firstname1, Lastname1).Build();

        Issue issue1 = IssueBuilderFactory.Create(IssueId1, IssueTitle1,null).WithPoints(Points1).WithDescription(Description1).Build();

    



        Sprint sprint1 = new(SprintId1, Startdate1, Enddate1);


        Issue issue2 = IssueBuilderFactory.Create(IssueId2, IssueTitle2, sprint1.Id)
        .WithPoints(Points2)
        .WithDescription(Description2)
        .WithAsignee(user1.UserId)
        .Build();

        Issue issue3 = IssueBuilderFactory.Create(IssueId3, IssueTitle3, sprint1.Id)
            .WithPoints(Points3)
            .WithDescription(Description3)
            .WithAsignee(user1.UserId)
            .Build();

        builder.Entity<Sprint>().HasData(sprint1);
        builder.Entity<Issue>().HasData(issue1, issue2, issue3);
    }
}
