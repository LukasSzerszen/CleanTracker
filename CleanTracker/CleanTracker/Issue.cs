using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTracker
{
    public class Issue
    {
        public int Id { get; }
        public string Description { get; }

        public Issue(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
