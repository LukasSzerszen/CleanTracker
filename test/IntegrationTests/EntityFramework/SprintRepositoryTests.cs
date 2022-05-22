using Domain;
using Domain.ValueObjects;
using Infrastructure.DataAccess.Repositories.EF;
using System;
using Xunit;
using static Domain.Issue;
using static Domain.Sprint;

namespace IntegrationTests.EntityFramework;
public class SprintRepositoryTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public SprintRepositoryTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void Get_Sprint_Does_Not_Throw_Exception()
    {
        SprintRepository repository = new(_fixture.Context);
        var actual = await Record.ExceptionAsync(() => repository.GetSprint(SeedData.SprintId1));

        Assert.Null(actual);
    }

    [Fact]
    public async void Get_Sprint_Gets_Existing_Sprint()
    {
        SprintRepository repository = new(_fixture.Context);
        var sprint = await repository.GetSprint(SeedData.SprintId1);

        Assert.NotNull(sprint);
    }

    [Fact]
    public async void Add_Sprint_Does_Not_Throw_Exception()
    {
        SprintRepository repository = new(_fixture.Context);
        Sprint sprint = SprintBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, TrackerDate.Build(DateTime.UtcNow).Value, TrackerDate.Build(DateTime.UtcNow.AddDays(10)).Value).Build()!;
        Issue issue1 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new sprint issue1").Value, null).WithSprint(sprint.Id).Build();
        Issue issue2 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new sprint issue2").Value, null).Build();
        Issue issue3 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new issue2, not in sprint").Value, null).Build();
        await _fixture.Context.Issues.AddRangeAsync(issue1, issue2, issue3);

        sprint.AddIssue(issue2);

        await repository.Add(sprint);

        Exception exception = await Record.ExceptionAsync(() => repository.GetSprint(sprint.Id));
        Sprint? updatedSprint = await repository.GetSprint(sprint.Id);

        Assert.Null(exception);
        Assert.Equal(2, updatedSprint!.Issues.Count);
        Assert.All(updatedSprint!.Issues, x => Assert.NotEqual(issue3.IssueId, x.IssueId));
    }

    [Fact]
    public async void Update_Sprint_Does_Not_Throw_Exception()
    {
        SprintRepository repository = new(_fixture.Context);
        Sprint sprint = SprintBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, TrackerDate.Build(DateTime.UtcNow).Value, TrackerDate.Build(DateTime.UtcNow.AddDays(10)).Value).Build()!;
        await _fixture.Context.Sprints.AddRangeAsync(sprint);
        Issue issue1 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new sprint issue1").Value, null).Build();
        Issue issue2 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new sprint issue2").Value, null).Build();
        await _fixture.Context.Issues.AddRangeAsync(issue1,issue2);
        sprint.AddIssue(issue1);
        sprint.AddIssue(issue2);

        Exception actual = await Record.ExceptionAsync(() =>  repository.Update(sprint));

        Assert.Null(actual);
    }

    [Fact]
    public async void Update_Sprint_Contains_Issues_In_Collection()
    {
        SprintRepository repository = new(_fixture.Context);
        Sprint sprint = SprintBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, TrackerDate.Build(DateTime.UtcNow).Value, TrackerDate.Build(DateTime.UtcNow.AddDays(10)).Value).Build()!;
        await _fixture.Context.Sprints.AddRangeAsync(sprint);
        Issue issue1 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new sprint issue1").Value, null).Build();
        Issue issue2 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new sprint issue2").Value, null).Build();
        await _fixture.Context.Issues.AddRangeAsync(issue1, issue2);
        sprint.AddIssue(issue1);
        sprint.AddIssue(issue2);

        await repository.Update(sprint);
        Sprint? updatedSprint = await _fixture.Context.Sprints.FindAsync(sprint.Id);

        Assert.NotNull(updatedSprint);
        Assert.Equal(2, updatedSprint!.Issues.Count);
    }


}
