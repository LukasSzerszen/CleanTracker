using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MoveIssue
{
    interface IMoveIssueUseCase
    {
        Task Execute(Guid IssueId);

        void SetOutPutPort(IOutPutPort outputPort);
    }
}
