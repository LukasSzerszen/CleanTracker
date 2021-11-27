using Domain;

namespace Application.UseCases.AddIssue;

public interface IOutputPort
{
    void Invalid();

    void Ok(Issue issue);

    void NotFound();

}
