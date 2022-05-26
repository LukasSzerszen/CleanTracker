using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.V1.Sprint.AddSprint;
using Xunit;

namespace ComponentTests.V1.Sprint;
public class AddSprintTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _fixture;

    public AddSprintTests(CustomWebApplicationFactory fixture) => _fixture = fixture;

    [Fact]
    public async Task AddSprintReturnsOK()
    {
        HttpClient client = _fixture.CreateClient();
        Uri requestUri = new($"api/v1/sprint/addsprint", UriKind.Relative);
        var request = new AddSprintRequest()
        {
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10),
        };

        string json = JsonConvert.SerializeObject(request);
        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage actualResponse = await client.PostAsync(requestUri, data);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
    }
}
