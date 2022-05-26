using System;

namespace Application.UseCases.AddIssue;

public sealed class AddIssueInput
{
    public string Title { get; set; } 

    public string? Description { get; set; }

    public int? Points { get; set; }

    public Guid? AssignedTo { get; set; }

    public string? Status { get; set; }
}
