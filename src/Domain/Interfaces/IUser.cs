using Domain.ValueObjects;

namespace Domain
{
    public interface IUser
    {
        public TrackerId Id { get; }
        public FirstName UserName { get; set;}
        public LastName UserLastName { get; set; }
        public string GetFullName();

    }
}
