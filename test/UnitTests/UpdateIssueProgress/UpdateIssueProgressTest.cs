using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UpdateIssueProgress
{
    public class UpdateIssueProgressTests: IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public UpdateIssueProgressTests(StandardFixture fixture) => _fixture = fixture;


    }
}
