using Application.UseCases.AddIssue;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase;

public interface IAddIssueUseCase
{
    Task Execute(AddIssueInput input);
    IAddIssueOutputPort OutputPort { get; set; }
}
