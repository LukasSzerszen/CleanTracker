﻿using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class StandardFixture
    {
        public IssueTrackerContextFake context;

        public StandardFixture()
        {
            context = new IssueTrackerContextFake();
        }
    }
}
