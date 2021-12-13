using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteIssue;

public class DeleteIssueUseCase : IDeleteIssueUseCase
{
    private readonly IIssueRepository _issueRepository;
    private IOutputPort _outputPort;

    public DeleteIssueUseCase(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
    public Task Execute(Guid issueId)
    {
        throw new NotImplementedException();
    }
}
