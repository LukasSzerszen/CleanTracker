namespace Application.UseCases.DeleteIssue;

public class DeleteIssuePresenter: IDeleteIssueOutputPort
{
    public bool OkOutput { get; private set; }
    public bool BadRequestOutput { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public void BadRequest() => this.BadRequestOutput = true;
    public void NotFound() => this.NotFoundOutput = true;
    public void Ok() => this.OkOutput = true;
}
