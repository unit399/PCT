﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PCT.Domain.Account.Entities;
using PCT.Domain.Account.RepositoryContracts;
using PCT.Domain.Common.RepositoryContracts;
using PCT.Domain.PersonalValue.RepositoryContracts;
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

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
                };
            });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPersonalValueRepository, PersonalValueRepository>();
        services.AddTransient<ApplicationDbContextSeed>();

        return services;
    }
}