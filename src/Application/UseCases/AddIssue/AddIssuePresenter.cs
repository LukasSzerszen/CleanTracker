using Domain;


namespace Application.UseCases.AddIssue
{
    public sealed class AddIssuePresenter : IAddIssueOutputPort
    {
        public Issue? Issue { get; private set; }
        public bool BadRequestOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void BadRequest() => this.BadRequestOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Issue issue) => this.Issue = issue;
    }
}
