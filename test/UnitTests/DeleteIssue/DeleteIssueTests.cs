using Application.UseCases.DeleteIssue;
using System;
using Xunit;

namespace UnitTests.DeleteIssue;

public sealed class DeleteIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public DeleteIssueTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void DeleteIssueUseCase_Removes_Issue_From_Collection()
    {
        DeleteIssuePresenter presenter = new();
        DeleteIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        var issueId = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890");

        await sut.Execute(issueId);

        Assert.True(presenter.OkOutput);
    }
}
