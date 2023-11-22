using Microsoft.OpenApi.Models;
using PCT.WebAPI.Extensions;
using PCT.Application;
using PCT.Infrastructure;

namespace PCT.WebAPI;

public static class InstallServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInfrastructure(configuration)
            .AddApplication();
            
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "PCT WebAPI",
                Version = "v1"
            });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please Insert JWT Bearer Token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{ }
                }
            });
        });

        services.ConfigureApiBehavior();
        services.ConfigureCorsPolicy();
        
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        return services;
    }
}