using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ComponentTests;

public sealed class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public CustomWebApplicationFactory() => Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "ComponentTests");
    protected override void ConfigureWebHost(IWebHostBuilder builder) => builder.ConfigureAppConfiguration((context, config) =>
    {
        config.AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["FeatureManagement:SqlServer"] = "false",
                }
            );
    });
}
