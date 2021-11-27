using Domain;


namespace Application.UseCases.AddIssue
{
    public sealed class AddIssuePresenter : IOutputPort
    {
        public Issue? Issue { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Issue issue) => this.Issue = issue;
    }
}
