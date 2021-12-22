using Domain;

namespace Application.UseCases.GetIssue;

public sealed class GetIssuePresenter : IGetIssueOutputPort
{
    public Issue? Issue { get; private set; }
    public bool InvalidOutput { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public void BadRequest() => this.InvalidOutput = true;
    public void NotFound() => this.NotFoundOutput = true;
    public void Ok(Issue issue) => this.Issue = issue;
}
