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
            var databaseName = configuration.GetValue<string>("Database:Name") ?? "AbacushDb";
            options.UseInMemoryDatabase(databaseName);
        });

        services.AddScoped<IUnitOfWork, Abacush.Infrastructure.UnitOfWork.UnitOfWork>();

        return services;
    }
}
