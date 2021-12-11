using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteIssue;

public interface IDeleteIssueUseCase
{
    Task Execute(Guid issueId);
    void SetOutputPort(IOutputPort outputPort);
}
