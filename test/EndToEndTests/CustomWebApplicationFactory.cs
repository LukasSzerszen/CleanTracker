using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EndToEndTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public CustomWebApplicationFactory() => Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "EndToEndTests");
    protected override void ConfigureWebHost(IWebHostBuilder builder) => builder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string>
            {
                ["FeatureManagement:SqlServer"] = "true",
                ["SqlServer:ConnectionString"] = "Server=localhost;User Id=sa;Password=Your_password123;Database=Issues;"

            });
        });
}
