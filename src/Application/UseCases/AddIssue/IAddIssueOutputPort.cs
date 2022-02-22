using Domain;

namespace Application.UseCases.AddIssue;

public interface IAddIssueOutputPort
{
    void BadRequest();

    void Ok(Issue issueId);

    void NotFound();

}
