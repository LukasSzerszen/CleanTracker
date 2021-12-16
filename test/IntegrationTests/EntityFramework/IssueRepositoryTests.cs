namespace IntegrationTests.EntityFramework;

using Infrastructure.Repositories;
using Xunit;

public sealed class IssueRepositoryTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public IssueRepositoryTests(StandardFixture fixture) => _fixture = fixture;
    
    [Fact]
    public async void GetIssueDoesNotThrowException()
    {
    }
}
