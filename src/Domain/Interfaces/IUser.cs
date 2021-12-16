using Domain.ValueObjects;

namespace Domain;

public interface IUser
{
    public TrackerId UserId { get; }
    public FirstName UserFirstName { get; }
    public LastName UserLastName { get; }
    public string GetUserName();

}
