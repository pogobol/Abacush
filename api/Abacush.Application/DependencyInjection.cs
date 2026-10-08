using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Wolverine;

namespace Abacush.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddWolverine(options =>
        {
            options.Discovery.IncludeAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}
