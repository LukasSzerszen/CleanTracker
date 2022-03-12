﻿
using Application.UseCases.AddIssueUseCase;
using Application.UseCases.GetIssue;
using Application.UseCases.UpdateIssue;
using Domain;

namespace WebApi.Modules.UseCaseExtensions;

public static class UseCaseExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<Notification, Notification>();
        services.AddScoped<IGetIssueUseCase, GetIssueUseCase>();
        services.AddScoped<V1.GetIssue.Presenter>();
        services.AddScoped<IAddIssueUseCase, AddIssueUseCase>();
        services.AddScoped<V1.AddIssue.Presenter>();
        services.AddScoped<IUpdateIssueUseCase, UpdateIssueUseCase>();
        services.AddScoped<V1.UpdateIssue.Presenter>();


        return services;
    }


}
