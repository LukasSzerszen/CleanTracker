using Application.UseCases.AddIssue;
using Application.UseCases.AddIssueUseCase;
using Domain;
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
        Notification notification = new();
        AddIssueUseCase sut = new(_fixture.IssueRepositoryFake, notification);
        sut.OutputPort = presenter;
        string issueTitle = "new issue";
        AddIssueInput input = new(issueTitle, null, null, null, null);

        await sut.Execute(input);

        Assert.NotNull(presenter.Issue);
    }
}
