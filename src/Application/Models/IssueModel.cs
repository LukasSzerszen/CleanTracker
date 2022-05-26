using System;

namespace Application.Models;
public sealed record IssueModel
{
    public Guid IssueId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? Points { get; set; }
    public Guid? AssignedTo { get; set; }
    public int? Status { get; set; }

}
