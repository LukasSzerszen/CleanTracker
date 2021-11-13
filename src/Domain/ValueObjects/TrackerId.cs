using System;

namespace Domain.ValueObjects
{
    public readonly struct TrackerId : IEquatable<TrackerId>
    {
        public Guid Id { get; }

        public TrackerId(Guid id) => this.Id = id;

        public bool Equals(TrackerId other) => this.Id == other.Id;

        public static bool operator ==(TrackerId left, TrackerId right) => left.Equals(right);

        public static bool operator !=(TrackerId left, TrackerId right) => !(left == right);

        public override string ToString() => this.Id.ToString();

        public override bool Equals(object obj) => obj is TrackerId id && Equals(id);

        public override int GetHashCode() => HashCode.Combine(this.Id);
    }
}
