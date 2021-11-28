using Domain;

namespace Application.UseCases.GetIssue;

public interface IOutputPort
{
    void Invalid();

    void Ok(Issue issue);

    void NotFound();

}
