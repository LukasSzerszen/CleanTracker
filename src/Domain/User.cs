using Domain.ValueObjects;
using System;
using System.Linq;


namespace Domain
{
    public class User : IUser
    {
        public TrackerId Id { get; }
        public FirstName UserName { get; set; }
        public LastName UserLastName { get; set; }

        public User(FirstName firstName, LastName lastName)
        {
            Id = new TrackerId(Guid.NewGuid());
            UserName = firstName;
            UserLastName = lastName;
        }
        public string GetFullName() => this.UserName.Name + " " + this.UserLastName.Name;

    }
}
