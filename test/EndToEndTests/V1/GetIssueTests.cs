using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EndToEndTests.V1;

public sealed class GetIssueTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _fixture;
    public GetIssueTests(CustomWebApplicationFactory fixture) => this._fixture = fixture;

    [Fact]
    public async Task GetIssueReturnsOk()
    {
        HttpClient client = this._fixture.CreateClient();
        var id = new Guid("31ed9c62-c367-42ed-aa63-2e68e4934890");
        Uri requestUri = new($"api/v1/Issue/{id}", UriKind.Relative);

        HttpResponseMessage actualResponse = await client.GetAsync(requestUri);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
    }
}
