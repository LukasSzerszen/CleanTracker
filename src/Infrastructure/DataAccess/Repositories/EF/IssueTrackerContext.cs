using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.DataAccess.Repositories.EF;

public sealed class IssueTrackerContext : DbContext
{

    public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options) : base(options)
    {
        
    }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Sprint> Sprints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IssueTrackerContext).Assembly);
        
        SeedData.Seed(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.EnableSensitiveDataLogging(true);
}
