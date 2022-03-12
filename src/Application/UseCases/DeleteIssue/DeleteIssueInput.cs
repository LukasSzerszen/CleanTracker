using System;

namespace Application.UseCases.DeleteIssue;

public record struct DeleteIssueInput(Guid IssueId);