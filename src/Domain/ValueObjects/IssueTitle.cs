using System;

namespace Domain.ValueObjects;

public record struct IssueTitle 
{
    public readonly string Title { get; }

    private IssueTitle(string title) => Title = title;

    public override string ToString() => Title;

    public override int GetHashCode() => HashCode.Combine(Title);

    public static Result<IssueTitle> Build(string issueTitle)
    {
        var result = new Result<IssueTitle>();
        if(issueTitle.Length <= 0)
        {
            result.Notifcation.Add(nameof(issueTitle), "can't be empty");
            return result;
        }
        if(issueTitle.Length > 60)
        {

        }
        result.Value = new IssueTitle(issueTitle);
        return result;

    }
}
