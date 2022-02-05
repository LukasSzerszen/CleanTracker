using Application.UseCases.GetIssue;
using Domain;
using WebApi.V1.GetIssue;

namespace WebApi.Modules.UseCaseExtensions;

public static class UseCaseExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<Notification, Notification>();
        services.AddScoped<IGetIssueUseCase, GetIssueUseCase>();
        services.AddScoped<Presenter, Presenter>();

        return services;
    }


}
