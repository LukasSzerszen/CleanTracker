namespace Application.UseCases.UpdateIssue;

public class UpdateIssuePresenter : IUpdateIssueOutputPort
{
    public bool OkOutput { get; private set; }
    public bool BadRequestOutput { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public void BadRequest() => BadRequestOutput = true;
    public void NotFound() => NotFoundOutput = true;
    public void Ok() => OkOutput = true;
}
