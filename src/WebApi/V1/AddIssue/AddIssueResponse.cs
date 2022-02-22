using Domain;
using System.ComponentModel.DataAnnotations;

namespace WebApi.V1.AddIssue;

public sealed class AddIssueResponse
{
    [Required]
    public Guid IssueId { get; set; }

    public AddIssueResponse(Issue issue)
    {
        IssueId = issue.IssueId.Id;
    }
}
