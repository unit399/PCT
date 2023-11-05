using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PCT.Application.Common.Interfaces.Services;
using PCT.Domain.PersonalValue.Persistence;
using PCT.Infrastructure.PersonalValue.Repository;
using PCT.Infrastructure.Services;

namespace PCT.Infrastructure;

public static class InstallServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(configuration)
            .AddPersistence();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql());
        //services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPersonalValueRepository, PersonalValueRepository>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        // var jwtSettings = new JwtSettings();
        // configuration.Bind(JwtSettings.SectionName, jwtSettings);
        //
        // services.AddSingleton(Options.Create(jwtSettings));
        //
        // services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        //
        // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //     .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuer = true,
        //         ValidateAudience = true,
        //         ValidateLifetime = true,
        //         ValidateIssuerSigningKey = true,
        //         ValidIssuer = jwtSettings.Issuer,
        //         ValidAudience = jwtSettings.Audience,
        //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        //     });

        return services;
    }
}