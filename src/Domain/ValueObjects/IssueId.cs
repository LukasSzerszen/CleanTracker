using System;

namespace Domain.ValueObjects
{
    public readonly struct IssueId : IEquatable<IssueId>
    {
        public Guid Id { get; }

        public IssueId(Guid id) => this.Id = id;
        public bool Equals(IssueId other) => this.Id == other.Id;

        public static bool operator ==(IssueId left, IssueId right) => left.Equals(right);

        public static bool operator !=(IssueId left, IssueId right) => !(left == right);

        public override string ToString() => this.Id.ToString();

        public override bool Equals(object obj) => obj is IssueId && Equals((IssueId)obj);

        public override int GetHashCode() => HashCode.Combine(this.Id);
    }
}
