namespace Application.UseCases.DeleteIssue;

public interface IDeleteIssueOutputPort
{
    void BadRequest();

    void Ok();

    void NotFound();

}
