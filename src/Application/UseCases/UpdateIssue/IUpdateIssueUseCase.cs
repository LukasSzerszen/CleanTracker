using System.Threading.Tasks;

namespace Application.UseCases.UpdateIssue;

public interface IUpdateIssueUseCase
{
    Task Execute(UpdateIssueInput input);
    IUpdateIssueOutputPort OutputPort { get; set; }
}
