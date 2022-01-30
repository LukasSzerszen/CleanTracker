namespace IntegrationTests.EntityFramework;

using Domain;
using Domain.ValueObjects;
using Infrastructure.DataAccess.Repositories.EF;
using Infrastructure.Repositories;
using System;
using System.Linq;
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
        var id = TrackerId.Build(Guid.NewGuid()).Value;
        Issue issueToAdd = IssueBuilderFactory.Create(id, SeedData.issueTitle3).Build();
        var ex = await Record.ExceptionAsync(async () => await issueRepository.Add(issueToAdd));
        var issue = await issueRepository.Get(id).ConfigureAwait(false);

        Assert.Null(ex);
        Assert.NotNull(issue);
    }

    [Fact]
    public async void Delete_Issue_Does_Not_Throw_Exception()
    {
        IssueRepository issueRepository = new IssueRepository(_fixture.Context);
        var id = TrackerId.Build(Guid.NewGuid()).Value;
        Issue issueToDelete = IssueBuilderFactory.Create(id, SeedData.issueTitle3).Build();
        await issueRepository.Add(issueToDelete);
        var ex = await Record.ExceptionAsync(async () => await issueRepository.Delete(id));
        bool hasDeletedAccount = _fixture.Context.Issues.Any(issue => issue.IssueId == id);

        Assert.Null(ex);
        Assert.False(hasDeletedAccount);
    }

    [Fact]
    public async void Update_Issue_Does_Not_Throw_Exception()
    {
        IssueRepository issueRepository = new IssueRepository(_fixture.Context);
        var updatedIssue = IssueBuilderFactory.Create(SeedData.IssueId2, SeedData.IssueTitle2).WithPoints(SeedData.Points3).WithDescription(SeedData.Description3).Build();
        var ex = await Record.ExceptionAsync(async () => await issueRepository.Update(updatedIssue));
        var issue = await issueRepository.Get(SeedData.IssueId2);

        Assert.Null(ex);
        Assert.Equal(updatedIssue.Points, issue.Points);
        Assert.Equal(updatedIssue.Status, issue.Status);
        Assert.Equal(updatedIssue.Description, issue.Description);
    }
}
