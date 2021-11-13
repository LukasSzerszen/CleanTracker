using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAssignable
    {
        public IUser AssignedTo { get; set; }
        public IssuePoints Points { get; set; }
        public void Assign(IUser assignee);
        public void UpdatePoints(IssuePoints points);

    }
}
