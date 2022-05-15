using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IUser
{
    public TrackerId UserId { get; }
    public FirstName UserFirstName { get; }
    public LastName UserLastName { get; }
    public string GetUserName();

}
