using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteIssue;

public interface IDeleteIssueUseCase
{
    Task Execute(DeleteIssueInput issueId);
    IDeleteIssueOutputPort OutputPort { get; set; }
}
