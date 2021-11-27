using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IAssignable
{
    public IUser AssignedTo { get; set; }
    public IssuePoints Points { get; set; }
    public void Assign(IUser assignee);
    public void UpdatePoints(IssuePoints points);

}
