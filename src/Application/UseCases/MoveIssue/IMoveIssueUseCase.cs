using Domain;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.MoveIssue
{
    interface IMoveIssueUseCase
    {
        Task Execute(Guid issueId, IssueProgressStatus issueProgressStauts);
    }
}
