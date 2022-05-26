using Domain;

namespace Application.UseCases.AddSprint;
public class AddSprintPresenter : IAddSprintOutputPort
{
    public bool BadRequestOutput { get; set; }
    public bool OkOutput { get; set; }
    public void BadRequest() => BadRequestOutput = true;
    public void Ok() => OkOutput = true;
}
