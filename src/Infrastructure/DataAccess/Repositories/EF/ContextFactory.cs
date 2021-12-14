using Infrastructure.DataAccess.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IntegrationTests.EntityFramework;

public class ContextFactory : IDesignTimeDbContextFactory<IssueTrackerContext>
{
    public IssueTrackerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IssueTrackerContext>();
        var connectionString = GetDeaultConnectionString();
        optionsBuilder.UseSqlServer(connectionString);

        return new IssueTrackerContext(optionsBuilder.Options);
    }


    private static string GetDeaultConnectionString()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
          .AddJsonFile("appsettings.json", false)
          .AddEnvironmentVariables()
          .Build();

        string connectionString = configuration.GetValue<string>("Sqlserver:ConnectionString");

        return connectionString;
    }
}
