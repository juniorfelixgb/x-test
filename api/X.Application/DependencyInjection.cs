using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using X.Application.Permissions.Services;
using X.Domain.Shared.Interfaces;

namespace X.Application;

public static class DependencyInjection
{
    public static readonly Assembly CurrentAssembly = typeof(DependencyInjection).Assembly;
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPermissionService, PermissionService>();

        return services;
    }
}
