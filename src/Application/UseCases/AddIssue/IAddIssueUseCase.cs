using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase
{
    public interface IAddIssueUseCase
    {
        Task Execute(IssueTitle IssueId);
    }
}
