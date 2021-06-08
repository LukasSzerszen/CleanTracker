using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MoveIssue
{
    public class MoveIssuePresenter : IOutPutPort
    {
        public void Invalid()
        {
            throw new NotImplementedException();
        }

        public void NotFound()
        {
            throw new NotImplementedException();
        }

        public void Ok(IIssue issue)
        {
            throw new NotImplementedException();
        }
    }
}
