using System.Reflection;
using Microsoft.OpenApi.Models;
using PCT.Application;
using PCT.Infrastructure;
using PCT.WebAPI.Extensions;
using PCT.WebAPI.Middleware;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

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
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.ConfigureApiBehavior();
        services.ConfigureCorsPolicy();

        services.AddEndpointsApiExplorer();
        services.AddControllers();

        ConfigureLogging();
       
        return services;
    }

    private static void ConfigureLogging()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ConfigureElasticSink(config, environment))
            .Enrich.WithProperty("Environment", environment)
            .ReadFrom.Configuration(config)
            .CreateLogger();
    }

    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot config, string? environment)
    {
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        if (name != null)
            return new ElasticsearchSinkOptions(new Uri(config["ElasticConfiguration:Uri"] ?? string.Empty))
            {
                AutoRegisterTemplate = true,
                IndexFormat =
                    $"{name.ToLower().Replace(".", "-")}-{environment?.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
                NumberOfReplicas = 1,
                NumberOfShards = 2
            };
        
        throw new Exception("Failed to get assembly name");
    }
}