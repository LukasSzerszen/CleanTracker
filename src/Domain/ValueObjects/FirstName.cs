using System;

namespace Domain.ValueObjects;

public readonly struct FirstName : IEquatable<FirstName>
{
    public string Name { get; }

    public FirstName(string name) => this.Name = name;

    public bool Equals(FirstName other) => this.Name == other.Name;

    public static bool operator ==(FirstName left, FirstName right) => left.Equals(right);

    public static bool operator !=(FirstName left, FirstName right) => !(left == right);

    public override string ToString() => this.Name.ToString();

    public override bool Equals(object obj) => obj is FirstName && Equals((TrackerId)obj);

    public override int GetHashCode() => HashCode.Combine(this.Name);
}
