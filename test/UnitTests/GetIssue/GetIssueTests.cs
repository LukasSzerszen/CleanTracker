using Application.UseCases.GetIssue;
using Domain.ValueObjects;
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
        GetIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        var issueId = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890");

        await sut.Execute(issueId);

        Assert.NotNull(presenter.Issue);
    }

}
