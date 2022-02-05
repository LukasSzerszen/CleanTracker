using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Modules.Common.FeatureFlags;
using WebApi.Modules.Common.Swagger;
using WebApi.Modules.SqlServerExtensions;
using WebApi.Modules.UseCaseExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddFeatureFlags(builder.Configuration)
    .AddVersionedSwagger()
    .AddUseCases()
    .AddSQLServer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options =>
        {
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

        }
    );
}
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }
