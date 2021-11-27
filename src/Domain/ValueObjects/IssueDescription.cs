using System;

namespace Domain.ValueObjects;

public readonly struct IssueDescription : IEquatable<IssueDescription>
{
    public string Description { get; }

    public IssueDescription(string description) => this.Description = description;

    public bool Equals(IssueDescription other) => this.Description == other.Description;

    public static bool operator ==(IssueDescription left, IssueDescription right) => left.Equals(right);

    public static bool operator !=(IssueDescription left, IssueDescription right) => !(left == right);

    public override string ToString() => this.Description.ToString();

    public override bool Equals(object obj) => obj is IssueDescription && Equals((IssueDescription)obj);

    public override int GetHashCode() => HashCode.Combine(this.Description);

}
