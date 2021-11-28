using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Builders;

public sealed class UserBuilder : IUserBuilder
{
    private User user;
    public UserBuilder(FirstName firstName, LastName lastName)
    {
        user = new User(firstName, lastName);
    }
    public IUser Build()
    {
        var result = user;
        user = null;
        return result;
    }
}
