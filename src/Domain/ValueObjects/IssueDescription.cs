using System;

namespace Domain.ValueObjects;

public record struct IssueDescription 
{
    public readonly string Description { get; }

    private IssueDescription(string description) => Description = description;

    public override string ToString() => this.Description.ToString();

    public override int GetHashCode() => HashCode.Combine(this.Description);

    public static Result<IssueDescription> Build(string description)
    {
        var result = new Result<IssueDescription>();
        result.Notifcation = new();
        if (description.Length > 80)
        {
            result.Notifcation.Add(nameof(description), "must be smaller than 80 characters");
            return result;
        }
        var issueDescription = new IssueDescription(description);
        result.Value = issueDescription;
        return result;
    }

}
