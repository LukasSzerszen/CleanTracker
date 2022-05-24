using Domain;

namespace Application.UseCases.AddSprint;
public class AddSprintPresenter : IAddSprintOutputPort
{
    public bool BadRequestOutput { get; set; }
    public bool NotFoundOutput { get; set; }
    public bool OkOutput { get; set; }
    public void BadRequest() => BadRequestOutput = true;
    public void NotFound() => NotFoundOutput = true;
    public void Ok(Sprint sprint) => OkOutput = true;
    public void OK() => OkOutput = true;
}
