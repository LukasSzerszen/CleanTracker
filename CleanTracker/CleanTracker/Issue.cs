using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTracker
{
    public class Issue
    {
        private string Id;
        private string Description;

        public Issue(string id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
