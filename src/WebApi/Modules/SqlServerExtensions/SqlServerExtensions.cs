using Domain.Interfaces;
using Infrastructure.DataAccess.Repositories.EF;
using Infrastructure.DataAccess.Repositories.Fakes;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using WebApi.Modules.Common.FeatureFlags;


namespace WebApi.Modules.SqlServerExtensions;

public static class SqlServerExtensions
{
    public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
    {
        IFeatureManager featureManager = services
            .BuildServiceProvider()
            .GetRequiredService<IFeatureManager>();
        bool isEnabled = featureManager
            .IsEnabledAsync(Features.SqlServer.ToString())
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();

        if (isEnabled)
        {
            services.AddDbContext<IssueTrackerContext>(options =>
            {
                options.UseSqlServer(configuration.GetValue<string>("SqlServer:ConnectionString")).EnableSensitiveDataLogging(true);
            }

            );
            services.AddScoped<IIssueRepository, IssueRepository>();
        }
        else
        {
            services.AddSingleton<IssueTrackerContextFake, IssueTrackerContextFake>();
            services.AddScoped<IIssueRepository, IssueRepositoryFake>();
            services.AddScoped<ISprintRepository, SprintRepositoryFake>();
        }

        return services;
    }
}
