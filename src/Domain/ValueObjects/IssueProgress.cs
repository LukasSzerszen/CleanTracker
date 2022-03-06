using System;

namespace Domain.ValueObjects;

public record struct IssueProgress
{
    public readonly IssueProgressStatus IssueProgressStatus { get; }

    private IssueProgress(IssueProgressStatus status) => IssueProgressStatus = status;

    public override string ToString() => this.IssueProgressStatus.ToString();

    public override int GetHashCode() => HashCode.Combine(this.IssueProgressStatus);

    public static Result<IssueProgress> Build(string status)
    {
        var result = new Result<IssueProgress>();
        bool isValid = Enum.TryParse(status,out IssueProgressStatus issueProgressStatus);
        if (!isValid)
        {
            result.Notifcation.Add(nameof(IssueProgress), "Invalid progress status");
        }
        result.Value = new IssueProgress(issueProgressStatus);
        return result;
    }




}
