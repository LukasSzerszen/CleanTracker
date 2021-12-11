using Domain.Interfaces;
using Domain.ValueObjects;
using System;

namespace Domain;

public class User : IUser
{
    public TrackerId Id { get; }
    public FirstName UserFirstName { get; private set; }
    public LastName UserLastName { get; private set; }

    public User(FirstName firstName, LastName lastName)
    {
        Id = TrackerId.Build(Guid.NewGuid()).Value;
        UserFirstName = firstName;
        UserLastName = lastName;
    }
    public string GetUserName() => this.UserFirstName.Name + " " + this.UserLastName.Name;

    public void ChangeFirstName(FirstName firstName) => this.UserFirstName = firstName;

    public void ChangeLastName(LastName lastName) => this.UserLastName = lastName;

    public class UserBuilder : IUserBuilder
    {
        private User User;

        public UserBuilder(FirstName firstName, LastName lastName)
        {
            User = new User(firstName, lastName);
        }

        public IUser Build()
        {
            var result = User;
            User = null;
            return result;
        }
    }

    public static class UserBuilderFactory
    {
        public static UserBuilder Create(FirstName firstName, LastName lastName)
        {
            return new UserBuilder(firstName, lastName);
        }
    }
}
