using System;

namespace Domain.ValueObjects
{
    public record IssueTitle : IEquatable<IssueTitle>
    {
        public string Title { get; init; }

        public IssueTitle(string title) => Title = title;

        public override string ToString() => Title;

        public override int GetHashCode() => HashCode.Combine(Title);
    }
}
