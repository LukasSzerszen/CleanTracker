using Application.UseCases.AddIssue;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetIssue;

public interface IGetIssueUseCase
{
    Task Execute(Guid issueId);
    void SetOutputPort(IOutputPort outputPort);
}
