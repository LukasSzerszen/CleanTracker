using Domain;

namespace Application.UseCases.MoveIssue;

public interface IOutputPort
{
    void Invalid();

    void Ok();

    void NotFound();

}
