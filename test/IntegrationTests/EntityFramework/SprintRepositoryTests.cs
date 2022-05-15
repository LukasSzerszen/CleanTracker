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
        var sprint = SprintBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, TrackerDate.Build(DateTime.UtcNow).Value, TrackerDate.Build(DateTime.UtcNow.AddDays(10)).Value).Build()!;
        var issue1 = IssueBuilderFactory.Create(TrackerId.Build(Guid.NewGuid()).Value, IssueTitle.Build("A new issue").Value, null);

    }
}
