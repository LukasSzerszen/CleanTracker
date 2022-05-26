using Domain;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;
using static Domain.Sprint;

namespace Application.UseCases.AddSprint;
public class AddSprintUseCase : IAddSprintUseCase
{
    public Notification Notification { get; set; }
    public IAddSprintOutputPort OutputPort { get; set; }
    public ISprintRepository Repository { get; set; }

    public AddSprintUseCase(Notification notification, ISprintRepository repository)
    {
        Notification = notification;
        OutputPort = new AddSprintPresenter();
        Repository = repository;
    }

    public async Task Execute(AddSprintInput input)
    {
        Result<TrackerDate> startDate = TrackerDate.Build(input.StartDate);
        Result<TrackerDate> endDate = TrackerDate.Build(input.EndDate);
        Notification.Add(startDate.Notifcation);
        Notification.Add(endDate.Notifcation);
        if (!Notification.isValid)
        {
            OutputPort.BadRequest();
            return;
        }
        TrackerId id = TrackerId.Build(Guid.NewGuid()).Value;
        Sprint sprint = SprintBuilderFactory.Create(id, startDate.Value, endDate.Value).Build()!;

        await Repository.Add(sprint);

        OutputPort.Ok(sprint);
    }
}
