namespace Application.UseCases.UpdateIssue;

public interface IUpdateIssueOutputPort
{
    void BadRequest();

    void Ok();

    void NotFound();
}
