using Infrastructure.DataAccess.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace IntegrationTests.EntityFramework;

public class StandardFixture : IDisposable
{
    public StandardFixture()
    {
        const string connectionString =
           "Server=localhost;User Id=sa;Password=Your_password123;Database=Issues;";
        DbContextOptions<IssueTrackerContext> options = new DbContextOptionsBuilder<IssueTrackerContext>()

      .UseSqlServer(connectionString)
      .Options;

        this.Context = new IssueTrackerContext(options);
        this.Context
            .Database
            .EnsureCreated();
    }

    public IssueTrackerContext Context { get; }

    public void Dispose() => this.Context.Dispose();
}
