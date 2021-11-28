using System;

namespace Domain.ValueObjects;

public record LastName : IEquatable<LastName>
{
    public string Name { get; }

    private LastName(string name) => this.Name = name;

    public override string ToString() => this.Name.ToString();

    public override int GetHashCode() => HashCode.Combine(this.Name);

    public static Result<LastName> Build(string name)
    {
        var result = new Result<LastName>();
        if(name.Length < 0)
        {
            result.Notifcation.Add(nameof(name), "can't be empty");
            return result;
        }
        result.Value = new LastName(name);
        return result;
    }
}
