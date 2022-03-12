using Application.UseCases.DeleteIssue;
using Domain.ValueObjects;
using System;
using Xunit;

namespace UnitTests.DeleteIssue;

public sealed class DeleteIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public DeleteIssueTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void DeleteIssueUseCase_Removes_Issue_From_Repository()
    {
        DeleteIssuePresenter presenter = new();
        DeleteIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        var issueId = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890");
        var trackerId = TrackerId.Build(new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890")).Value;

        var issue = _fixture.IssueRepositoryFake.Get(trackerId);
        Assert.NotNull(issue.Result);

        DeleteIssueInput input = new()
        {
            IssueId = issueId
        };
        await sut.Execute(input);

        issue = _fixture.IssueRepositoryFake.Get(trackerId);

        Assert.Null(issue.Result);
    }

    [Fact]
    public async void DeleteIssueUseCase_Does_Not_Throw_Exception_When_Id_Not_In_Repository()
    {
        DeleteIssuePresenter presenter = new();
        DeleteIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        var notPresentId = new Guid("85de3566-13cd-44e6-bbea-9057f86dfbb0");
        var issueId1 = TrackerId.Build(new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890")).Value;
        var issueId2 = TrackerId.Build(new Guid("035fecc7-5bcc-4c9e-b7d8-34113e722298")).Value;

        DeleteIssueInput input = new()
        {
            IssueId = notPresentId
        };

        await sut.Execute(input);
        var issue1 = _fixture.IssueRepositoryFake.Get(issueId1);
        var issue2 = _fixture.IssueRepositoryFake.Get(issueId2);
        Assert.NotNull(issue1.Result); 
        Assert.NotNull(issue2.Result);
    }
}
