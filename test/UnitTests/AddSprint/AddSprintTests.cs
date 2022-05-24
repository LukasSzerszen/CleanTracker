using Application.UseCases.AddSprint;
using Domain;
using Domain.Interfaces;
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
        Notification notification = new();
        ISprintRepository repository = _fixture.SprintRepositoryFake;
        AddSprintUseCase sut = new(notification, repository);
        AddSprintInput input = new();

        Exception actual = await Record.ExceptionAsync(() => sut.Execute(input));

        Assert.Null(actual);
    }
}
