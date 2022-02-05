using Application.UseCases.GetIssue;
using Domain;
using System;
using Xunit;

namespace UnitTests.GetIssue;

public sealed class GetIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public GetIssueTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void GetIssueUseCase_Returns_Issue_From_Repsitory()
    {
        GetIssuePresenter presenter = new();
        Notification notification = new();
        GetIssueUseCase sut = new(_fixture.IssueRepositoryFake, notification);
        sut.OutputPort = presenter;
        var issueId = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890");
        GetIssueInput input = new(issueId);
        await sut.Execute(input);

        Assert.NotNull(presenter.Issue);
    }

}
