using System.ComponentModel.DataAnnotations;

namespace WebApi.V1.DeleteIssue;

public class DeleteIssueRequest
{
    [Required]
    public Guid IssueId { get; set; }
}
