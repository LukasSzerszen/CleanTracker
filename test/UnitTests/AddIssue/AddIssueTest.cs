using Application.UseCases.AddIssue;
using Application.UseCases.AddIssueUseCase;
using Xunit;

namespace UnitTests.AddIssue;

public sealed class AddIssueTest : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public AddIssueTest(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public void AddIssueUseCase_Adds_Issue_To_Collection()
    {
        AddIssuePresenter presenter = new();
        AddIssueUseCase sut = new(_fixture.IssueRepositoryFake);
        sut.SetOutputPort(presenter);
        string issueTitle = "new issue";

        sut.Execute(issueTitle);

        Assert.NotNull(presenter.Issue);
    }
}
