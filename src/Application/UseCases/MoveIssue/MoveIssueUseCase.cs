using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MoveIssue
{
    public class MoveIssueUseCase : IMoveIssueUseCase
    {
        private readonly IIssueRepository _issueRepository;
        public Task Execute(Guid IssueId)
        {
            throw new NotImplementedException();
        }

        public void SetOutPutPort(IOutPutPort outputPort)
        {
            throw new NotImplementedException();
        }
    }
}
