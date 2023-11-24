using System.Reflection;
using FluentValidation;
using MediatR;
using PCT.Application.Common.Behaviors;

namespace PCT.Application;

public static class InstallServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(InstallServices).Assembly);
        services.AddAutoMapper(typeof(InstallServices).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}