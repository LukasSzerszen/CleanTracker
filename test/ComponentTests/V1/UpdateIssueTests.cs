using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.V1.UpdateIssue;
using Xunit;

namespace ComponentTests.V1;

public sealed class UpdateIssueTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _fixture;

    public UpdateIssueTests(CustomWebApplicationFactory fixture) => this._fixture = fixture;

    [Fact]
    public async Task UpdateIssueReturnsOk()
    {
        HttpClient client = this._fixture.CreateClient();
        Guid id = new Guid("cb333ef9-9986-45ef-8872-e3429afb6d3a");
        int newPoints = 2;
        UpdateIssueRequest updateIssueRequest = new()
        {
            IssueId = id,
            Points = newPoints,
        };

        string json = JsonConvert.SerializeObject(updateIssueRequest);
        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
        Uri requestUri = new($"api/v1/Issue/updateissue", UriKind.Relative);

        HttpResponseMessage actualResponse = await client.PostAsync(requestUri, data);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
    }
}
