using System;

namespace Domain.ValueObjects;

public record TrackerId 
{
    public Guid Id { get; }

    private TrackerId(Guid id) => this.Id = id;

    public override string ToString() => this.Id.ToString();

    public override int GetHashCode() => HashCode.Combine(this.Id);

    public static Result<TrackerId> Build(Guid id)
    {
        var result = new Result<TrackerId>();
        result.Value = new TrackerId(id);
        return result;
    }
}
