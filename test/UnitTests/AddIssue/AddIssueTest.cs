using Application.UseCases.AddIssueUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.AddIssue
{
    public sealed class AddIssueTest
    {
        private readonly StandardFixture _fixture;

        public AddIssueTest(StandardFixture fixture) => _fixture = fixture;

        [Fact]
        public void AddIssueUseCase_Adds_Issue_To_Collection()
        {
            
            AddIssueUseCase sut = new AddIssueUseCase(_fixture.IssueRepositoryFake);

        }
    }
}
