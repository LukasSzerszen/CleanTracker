using Application.UseCases.AddIssue;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase
{
    public interface IAddIssueUseCase
    {
        Task Execute(string IssueId);
        void SetOutputPort(IOutputPort outputPort);
    }
}
