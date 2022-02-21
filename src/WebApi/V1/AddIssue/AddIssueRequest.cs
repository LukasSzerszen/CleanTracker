using System.ComponentModel.DataAnnotations;

namespace WebApi.V1.AddIssue;

public sealed class AddIssueRequest
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    public int? Points { get; set; }

    public Guid? AssignedTo { get; set; }

    public string? Status { get; set; }

}
