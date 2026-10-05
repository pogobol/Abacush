using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Abacush.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AbacushDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Abacush")
                ?? throw new InvalidOperationException(
                    $"Connection string Abacush was not found.");

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork, Abacush.Infrastructure.UnitOfWork.UnitOfWork>();

        return services;
    }
}
