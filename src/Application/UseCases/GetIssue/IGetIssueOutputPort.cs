using Domain;

namespace Application.UseCases.GetIssue;

public interface IGetIssueOutputPort
{
    void BadRequest();

    void Ok(Issue issue);

    void NotFound();

}
