using System;

namespace Domain.ValueObjects
{
    public readonly struct LastName : IEquatable<LastName>
    {
        public string Name { get; }

        public LastName(string name) => this.Name = name;

        public bool Equals(LastName other) => this.Name == other.Name;

        public static bool operator ==(LastName left, LastName right) => left.Equals(right);

        public static bool operator !=(LastName left, LastName right) => !(left == right);

        public override string ToString() => this.Name.ToString();

        public override bool Equals(object obj) => obj is LastName && Equals((TrackerId)obj);

        public override int GetHashCode() => HashCode.Combine(this.Name);

    }
}
