using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase
{
    public class AddIssueUseCase : IAddIssueUseCase
    {
        private readonly IIssueRepository _issueRepository;

        public AddIssueUseCase(IIssueRepository issueRepository) => _issueRepository = issueRepository;
        public Task Execute(IssueTitle IssueId)
        {
            throw new NotImplementedException();
        }
    }
}
