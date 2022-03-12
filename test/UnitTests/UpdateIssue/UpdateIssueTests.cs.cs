using Application.UseCases.AddIssue;
using Application.UseCases.AddIssueUseCase;
using Application.UseCases.UpdateIssue;
using Domain;
using Domain.ValueObjects;
using System;
using Xunit;
using static Domain.Issue;

namespace UnitTests.UpdateIssue;

public sealed class UpdateIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;
    public UpdateIssueTests(StandardFixture fixture) => _fixture = fixture;
    [Fact]
    public async void UpdateIssueUseCase_Updates_Issue()
    {
        Notification notification = new();
        UpdateIssuePresenter presenter = new();
        UpdateIssueUseCase sut = new(notification, _fixture.IssueRepositoryFake);
        sut.OutputPort = presenter;
        string issueTitle = "Update Issue";
        string description = "new description";
        string status = "ReadyForRelease";
        int points = 8;
        TrackerId issueId = TrackerId.Build(Guid.NewGuid()).Value;
        IssueTitle title = IssueTitle.Build(issueTitle).Value;
        Issue issue = IssueBuilderFactory.Create(issueId, title).Build();
        await _fixture.IssueRepositoryFake.Add(issue);

        UpdateIssueInput request = new()
        {
            IssueId = issueId.Id,
            Description = description,
            Points = points,
            Status = status
        };

        await sut.Execute(request);

        issue = await _fixture.IssueRepositoryFake.Get(issueId);

        Assert.NotNull(issue);
        Assert.Equal(description, issue.Description.Value.Description);
        Assert.Equal(points, issue.Points.Value.Points);
        Assert.Equal(status, issue.Status.Value.ToString());
    }
}
