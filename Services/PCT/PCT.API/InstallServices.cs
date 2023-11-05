using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using PCT.API.Common.MappingProfiles;
using PCT.Application;
using PCT.Infrastructure;

namespace PCT.API;

public static class InstallServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        services
            .AddInfrastructure(configuration)
            .AddApplication()
            .AddMappings()
            .AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PCT API",
                    Version = "v1"
                });
            });

        return services;
    }
}