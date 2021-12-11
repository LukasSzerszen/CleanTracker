namespace Application.UseCases.DeleteIssue;

public class DeleteIssuePresenter: IOutputPort
{
    public bool OkOutput { get; private set; }
    public bool InvalidOutput { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public void Invalid() => this.InvalidOutput = true;
    public void NotFound() => this.NotFoundOutput = true;
    public void Ok() => this.OkOutput = true;
}
