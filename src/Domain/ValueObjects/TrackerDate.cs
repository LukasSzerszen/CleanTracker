using System;

namespace Domain.ValueObjects;

public record struct TrackerDate 
{
    public readonly DateTime Date { get; }

    private TrackerDate(DateTime date) => this.Date = date;

    public override string ToString() => this.Date.ToString();

    public override int GetHashCode() => HashCode.Combine(this.Date);

    public static Result<TrackerDate> Build(DateTime date)
    {
        var result = new Result<TrackerDate>();
        result.Value = new TrackerDate(date);
        return result;
    }

}
