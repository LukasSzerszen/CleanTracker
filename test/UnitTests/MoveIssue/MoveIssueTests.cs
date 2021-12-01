using Application.UseCases.MoveIssue;
using Domain;
using Domain.ValueObjects;
using System;
using Xunit;

namespace UnitTests.MoveIssue;

public sealed class MoveIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public MoveIssueTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void MoveIssueUseCase_Updates_Progress_Status()
    {
        MoveIssuePresenter presenter = new();
        MoveIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        var issueId = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890");
        var newProgressStatus = IssueProgressStatus.ReadyForTest;

        await sut.Execute(issueId, newProgressStatus);

        var id = TrackerId.Build(issueId).Value;
        var issue = await _fixture.IssueRepositoryFake.Get(id);

        Assert.Equal(issue.Status, newProgressStatus);
    }
}
