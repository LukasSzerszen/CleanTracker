using System;

namespace Domain.ValueObjects;

public record struct IssuePoints 
{
    public readonly int Points { get; }
   
    private IssuePoints(int points) => Points = points;

    public override string ToString() => Points.ToString();

    public override int GetHashCode() => HashCode.Combine(this.Points);

    public static Result<IssuePoints> Build(int points)
    {
        var result = new Result<IssuePoints>();
        if(points <= 0)
        {
            result.Notifcation.Add(nameof(points), "must be larger than zero");
            return result;
        }
        var issuePoints = new IssuePoints(points);
        result.Value = issuePoints;
        return result;
    }

}
