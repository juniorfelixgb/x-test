using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using X.Domain.Shared.Interfaces;
using X.Infrastructure.Middlewares;
using X.Infrastructure.Repositories;

namespace X.Infrastructure;

public static class DependencyInyection
{
    public static readonly Assembly CurrentAssembly = typeof(DependencyInyection).Assembly;
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDbContext, AppDbContext>();

        string connectionString = configuration.GetConnectionString("xConn");
        _ = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
        services.AddScoped<IEmployeeRespository, EmployeeRespository>();

        services.AddScoped<ErrorHandlerMiddleware>();

        return services;
    }
}
