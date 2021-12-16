namespace IntegrationTests.EntityFramework;

using Domain;
using Infrastructure.DataAccess.Repositories.EF;
using Infrastructure.Repositories;
using Xunit;
using static Domain.Issue;

public sealed class IssueRepositoryTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public IssueRepositoryTests(StandardFixture fixture) => _fixture = fixture;

    [Fact]
    public async void Add_Issue_Does_Not_Throw_Exception()
    {
        IssueRepository issueRepository = new IssueRepository(_fixture.Context);
        Issue issueToAdd = IssueBuilderFactory.Create(SeedData.IssueId3, SeedData.issueTitle3).Build();
        var ex = await Record.ExceptionAsync(async () => await issueRepository.Add(issueToAdd).ConfigureAwait(false));
        var issue = await issueRepository.Get(SeedData.IssueId3).ConfigureAwait(false);

        Assert.Null(ex);
        Assert.NotNull(issue);
    }

    [Fact]
    public async void Delete_Issue_Does_Not_Throw_Exception()
    {
        IssueRepository issueRepository = new IssueRepository(_fixture.Context);
        var issueToDelete = SeedData.IssueId2;
        var ex = await Record.ExceptionAsync(async () => await issueRepository.Delete(issueToDelete).ConfigureAwait(false));
        var issue = await issueRepository.Get(SeedData.IssueId2).ConfigureAwait(false);

        Assert.Null(ex);
        Assert.Null(issue);
    }

    [Fact]
    public async void Update_Issue_Does_Not_Throw_Exception()
    {
        IssueRepository issueRepository = new IssueRepository(_fixture.Context);
        var updatedIssue = IssueBuilderFactory.Create(SeedData.IssueId2, SeedData.IssueTitle2).WithPoints(SeedData.Points3).WithDescription(SeedData.Description3).Build();
        var ex = await Record.ExceptionAsync(async () => await issueRepository.Update(updatedIssue).ConfigureAwait(false));
        var issue = await issueRepository.Get(SeedData.IssueId2).ConfigureAwait(false);

        Assert.Null(ex);
        Assert.Equal(updatedIssue, issue);
    }
}
