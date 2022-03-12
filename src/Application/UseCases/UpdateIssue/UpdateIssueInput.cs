using System;

namespace Application.UseCases.UpdateIssue;

public record struct UpdateIssueInput(Guid IssueId, string? Title, string? Description, int? Points, Guid? AssignedTo, string? Status);

