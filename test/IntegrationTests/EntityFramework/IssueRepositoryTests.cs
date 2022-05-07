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
        Issue issueToAdd = IssueBuilderFactory.Create(id, SeedData.IssueTitle3, null).Build();
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
        Issue issueToDelete = IssueBuilderFactory.Create(id, SeedData.IssueTitle3, null).Build();
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

        string issueTitle = "Update Issue";
        string description = "new description";
        int points = 8;
        TrackerId issueId = TrackerId.Build(Guid.NewGuid()).Value;
        IssueTitle title = IssueTitle.Build(issueTitle).Value;
        IssueDescription issueDescription = IssueDescription.Build(description).Value;
        IssueProgressStatus progressStatus = IssueProgressStatus.ReadyForRelease;
        IssuePoints issuePoints = IssuePoints.Build(points).Value;
        Issue issue = IssueBuilderFactory.Create(issueId, title, null).Build();

        await issueRepository.Add(issue);

        Exception ex = await Record.ExceptionAsync(async () => await issueRepository.Update(issueId, null, issueDescription, issuePoints, null, progressStatus));

        Issue updatedIssue = await issueRepository.Get(issueId);

        Assert.Null(ex);
        Assert.Equal(issuePoints, updatedIssue!.Points);
        Assert.Equal(progressStatus, updatedIssue.Status);
        Assert.Equal(issueDescription, updatedIssue.Description);
    }
}
