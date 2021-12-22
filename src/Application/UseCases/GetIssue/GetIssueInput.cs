using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GetIssue;

public sealed class GetIssueInput
{
    public Guid IssueId { get; set; }
    public GetIssueInput(Guid IssueId)
    {
        this.IssueId = IssueId;
    }
    public void Validate(Notification notification)
    {
        
    }
}
