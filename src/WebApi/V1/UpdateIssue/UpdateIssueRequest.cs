using System.ComponentModel.DataAnnotations;

namespace WebApi.V1.UpdateIssue;

public class UpdateIssueRequest
{
    [Required]
    public Guid IssueId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Points { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Status { get; set; }
}
