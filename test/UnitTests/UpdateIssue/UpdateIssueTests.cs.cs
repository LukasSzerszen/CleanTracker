using Application.UseCases.AddIssue;
using Application.UseCases.AddIssueUseCase;
using Application.UseCases.UpdateIssue;
using Domain;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UpdateIssue;

public sealed class UpdateIssueTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;
    public UpdateIssueTests(StandardFixture fixture) => _fixture = fixture;
    [Fact]
    public async void UpdateIssueUseCase_Updates_Issue()
    {
        AddIssuePresenter addIssuePresenter = new();
        Notification notification = new();
        AddIssueUseCase addIssueUseCase = new(notification, _fixture.IssueRepositoryFake);
        addIssueUseCase.OutputPort = addIssuePresenter;
        UpdateIssuePresenter presenter = new();
        UpdateIssueUseCase sut = new(notification, _fixture.IssueRepositoryFake);
        sut.OutputPort = presenter;
        Guid id = Guid.NewGuid();
        string issueTitle = "Update Issue";
        string description = "new description";
        string status = "ReadyForRelease";
        int points = 8;


        AddIssueInput addIssueInput = new()
        {
            Title = issueTitle,
            Description = null,
            AssignedTo = null,
            Points = null,
            Status = null,
        };

        await addIssueUseCase.Execute(addIssueInput);

        TrackerId issueId = addIssuePresenter.Issue.IssueId;

        UpdateIssueRequest request = new()
        {
            IssueId = issueId.Id,
            Description = description,
            Points = points,
            Status = status
        };

        await sut.Execute(request);

        Issue issue = await _fixture.IssueRepositoryFake.Get(issueId);

        Assert.NotNull(issue);
        Assert.Equal(description, issue.Description.Value.Description);
        Assert.Equal(points, issue.Points.Value.Points);
        Assert.Equal(status, issue.Status.Value.ToString());
    }
}
