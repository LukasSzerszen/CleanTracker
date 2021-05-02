﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTracker
{
    public class Issue
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Issue(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
