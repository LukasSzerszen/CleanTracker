using Domain;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

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
        throw new NotImplementedException();
    }
}
