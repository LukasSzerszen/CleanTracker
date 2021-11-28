using System;

namespace Domain.ValueObjects;

public readonly struct TrackerDate : IEquatable<TrackerDate>
{
    public DateTime Date { get; }

    public TrackerDate(DateTime date) => this.Date = date;

    public bool Equals(TrackerDate other) => this.Date == other.Date;

    public static bool operator ==(TrackerDate left, TrackerDate right) => left.Equals(right);

    public static bool operator !=(TrackerDate left, TrackerDate right) => !(left == right);

    public override string ToString() => this.Date.ToString();

    public override bool Equals(object obj) => obj is TrackerDate && Equals((TrackerId)obj);

    public override int GetHashCode() => HashCode.Combine(this.Date);

}
