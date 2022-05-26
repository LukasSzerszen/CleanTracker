using Application.UseCases.AddSprint;
using Domain;
using System;
using Xunit;

namespace UnitTests.AddSprint;
public class AddSprintTests : IClassFixture<StandardFixture>
{
    public StandardFixture _fixture { get; set; }
    public AddSprintTests(StandardFixture fixture) => _fixture = fixture;


    [Fact]
    public async void AddSprintUseCase_Does_Not_Throw_Exception()
    {
        AddSprintPresenter presenter = new();
        Notification notification = new();
        AddSprintUseCase sut = new(notification, _fixture.SprintRepositoryFake);
        sut.OutputPort = presenter;
        AddSprintInput input = new()
        {
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10),
        };

        Exception actual = await Record.ExceptionAsync(() => sut.Execute(input));

        Assert.Null(actual);
    }
}
