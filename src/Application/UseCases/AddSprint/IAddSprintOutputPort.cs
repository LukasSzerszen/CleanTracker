using Domain;

namespace Application.UseCases.AddSprint;
public interface IAddSprintOutputPort
{
    void BadRequest();
    void Ok(Sprint sprint);
    void OK();
    void NotFound();
}
