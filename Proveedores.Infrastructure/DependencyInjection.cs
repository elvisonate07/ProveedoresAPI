using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proveedores.Application.Common.Interfaces;
using Proveedores.Domain.Interfaces;
using Proveedores.Infrastructure.Data;
using Proveedores.Infrastructure.Repositories;
using Proveedores.Infrastructure.Services;

namespace Proveedores.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDb")!;
        var databaseName = configuration["MongoDb:DatabaseName"]!;

        services.AddSingleton(new MongoDbContext(connectionString, databaseName));
        services.AddScoped<IProveedorRepository, ProveedorRepository>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
