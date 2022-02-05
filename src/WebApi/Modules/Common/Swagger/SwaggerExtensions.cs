using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;

namespace WebApi.Modules.Common.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddVersionedSwagger(this IServiceCollection services)
    {
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
        });

        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
                var assemblyDescription = typeof(StartupBase).Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = $"{typeof(StartupBase).Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product} {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = description.IsDeprecated ? $"{assemblyDescription} - DEPRECATED" : $"{assemblyDescription}"
                    });
                }
            }

            var currentAssembly = Assembly.GetExecutingAssembly();
            var xmlDocs = currentAssembly.GetReferencedAssemblies()
            .Union(new AssemblyName[] { currentAssembly.GetName() })
            .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
            .Where(f => File.Exists(f)).ToArray();

            Array.ForEach(xmlDocs, (d) =>
            {
                options.IncludeXmlComments(d);
            });
        });

        return services;
    }
}
