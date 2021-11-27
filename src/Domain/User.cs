using Domain.ValueObjects;


namespace Domain;

public class User : IUser
{
    public TrackerId Id { get; }
    public FirstName UserName { get; set; }
    public LastName UserLastName { get; set; }

    public User(TrackerId id, FirstName firstName, LastName lastName)
    {
        Id = id;
        UserName = firstName;
        UserLastName = lastName;
    }
    public string GetFullName() => this.UserName.Name + " " + this.UserLastName.Name;

}
