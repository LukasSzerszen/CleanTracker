using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetIssue;

public interface IGetIssueUseCase
{
    Task Execute(GetIssueInput issueId);
    IGetIssueOutputPort OutputPort { get; set; }
}
