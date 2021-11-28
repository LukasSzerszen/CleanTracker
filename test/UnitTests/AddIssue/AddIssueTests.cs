using Application.UseCases.AddIssue;
using Application.UseCases.AddIssueUseCase;
using Xunit;

namespace UnitTests.AddIssue;

public sealed class AddIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public AddIssueTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void AddIssueUseCase_Adds_Issue_To_Collection()
    {
        AddIssuePresenter presenter = new();
        AddIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        string issueTitle = "new issue";

        await sut.Execute(issueTitle);

        Assert.NotNull(presenter.Issue);
    }
}
