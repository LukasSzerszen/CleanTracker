using System.Threading.Tasks;

namespace Application.UseCases.UpdateIssue;

internal interface IUpdateIssueUseCase
{
    Task Execute(UpdateIssueRequest input);
    IUpdateIssueOutputPort OutputPort { get; set; }
}
