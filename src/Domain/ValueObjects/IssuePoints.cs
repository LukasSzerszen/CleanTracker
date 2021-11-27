using System;

namespace Domain.ValueObjects;

public readonly struct IssuePoints : IEquatable<IssuePoints>
{
    public int Points { get; }

    public IssuePoints(int points) => Points = points;

    public bool Equals(IssuePoints other) => this.Points == other.Points;

    public static bool operator ==(IssuePoints left, IssuePoints right) => left.Equals(right);

    public static bool operator !=(IssuePoints left, IssuePoints right) => !(left == right);

    public override string ToString() => this.Points.ToString();

    public override bool Equals(object obj) => obj is IssuePoints && Equals((IssuePoints)obj);

    public override int GetHashCode() => HashCode.Combine(this.Points);

}
