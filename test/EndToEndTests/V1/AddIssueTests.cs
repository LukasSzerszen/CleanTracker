using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.V1.AddIssue;
using Xunit;

namespace EndToEndTests.V1;

public sealed class AddIssueTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _fixture;
    public AddIssueTests(CustomWebApplicationFactory fixture) => _fixture = fixture;

    [Fact]
    public async Task AddIssueReturnsOk()
    {
        HttpClient client = _fixture.CreateClient();
        Uri requestUri = new($"api/v1/Issue/addissue", UriKind.Relative);
        var request = new AddIssueRequest()
        {
            Title = "new issue title",
            Description = "issue description"
        };

        string json = JsonConvert.SerializeObject(request);
        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage actualResponse = await client.PostAsync(requestUri, data);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
    }

}
