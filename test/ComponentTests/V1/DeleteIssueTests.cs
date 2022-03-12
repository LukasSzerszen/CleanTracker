using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.V1.DeleteIssue;
using Xunit;

namespace ComponentTests.V1;

public sealed class DeleteIssueTests: IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _fixture;

    public DeleteIssueTests(CustomWebApplicationFactory fixture) => this._fixture = fixture;

    [Fact]
    public async Task DeleteIssueReturnsOk()
    {
        HttpClient client = this._fixture.CreateClient();
        Guid id = new Guid("cb333ef9-9986-45ef-8872-e3429afb6d3a");
        DeleteIssueRequest deleteIssueRequest = new()
        {
            IssueId = id,
        };

        string json = JsonConvert.SerializeObject(deleteIssueRequest);
        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
        Uri requestUri = new($"api/v1/Issue/deleteissue", UriKind.Relative);

        HttpResponseMessage actualResponse = await client.PostAsync(requestUri, data);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
    }
}
