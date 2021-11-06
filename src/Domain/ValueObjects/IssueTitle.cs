using System;

namespace Domain.ValueObjects
{
    public readonly struct IssueTitle : IEquatable<IssueTitle>
    {
        public string Title { get; }

        public IssueTitle(string title) => Title = title;
        public bool Equals(IssueTitle other) => Title == other.Title;
        public static bool operator ==(IssueTitle left, IssueTitle right) => left.Equals(right);

        public static bool operator !=(IssueTitle left, IssueTitle right) => !(left == right);

        public override string ToString() => Title;

        public override bool Equals(object obj) => obj is IssueTitle && Equals((IssueTitle)obj);

        public override int GetHashCode() => HashCode.Combine(Title);
    }
}
