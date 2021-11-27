using System;
using System.Threading.Tasks;

namespace Application.UseCases.MoveIssue
{
    interface IMoveIssueUseCase
    {
        Task Execute(Guid IssueId);
    }
}
