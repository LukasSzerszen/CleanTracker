using System;

namespace Domain.ValueObjects;

public record struct FirstName
{
    public readonly string Name { get; }

    private FirstName(string name) => this.Name = name;

    public override string ToString() => this.Name.ToString();

    public override int GetHashCode() => HashCode.Combine(this.Name);

    public static Result<FirstName> Build(string name)
    {
        var result = new Result<FirstName>();
        if(name.Length <= 0)
        {
            result.Notifcation.Add(nameof(name), "can't be empty");
            return result;
        }

        result.Value = new FirstName(name);
        return result;
    }
}
