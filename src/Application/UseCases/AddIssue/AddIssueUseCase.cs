using Application.UseCases.AddIssue;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.AddIssueUseCase
{
    public class AddIssueUseCase : IAddIssueUseCase
    {
        private readonly IIssueRepository _issueRepository;
        private IOutputPort _outputPort;

        public AddIssueUseCase(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
            _outputPort = new AddIssuePresenter();
        }
        public Task Execute(string Issuetitle)
        {
            throw new NotImplementedException();
        }

        public void SetOutputPort(IOutputPort output)
        {
            _outputPort = output;
        }
    }
}
