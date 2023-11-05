using System.Reflection;
using Mapster;
using MapsterMapper;

namespace PCT.API.Common.MappingProfiles;

public static class InstallMapster
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}