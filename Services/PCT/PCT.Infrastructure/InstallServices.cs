using Microsoft.EntityFrameworkCore;
using PCT.Application.Repositories;
using PCT.Infrastructure.Context;
using PCT.Infrastructure.Repositories;

namespace PCT.Infrastructure;

public static class InstallServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql());
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            if (connectionString != null) opt.UseSqlite(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPersonalValueRepository, PersonalValueRepository>();
        
        return services;
    }
}