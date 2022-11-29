using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Examples.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceWithAttributes(this IServiceCollection servies)
    {
        var provider = servies.BuildServiceProvider();
        var logger = provider.GetRequiredService<ILogger<ServiceRegistoartionAttribute>>();

        foreach (var (service, implement) in EnumerateServcieTypes<SingletonServiceRegistoartionAttribute>())
        {
            servies.Add(ServiceDescriptor.Scoped(service, implement));
            logger.LogDebug(".AddSingleton<{service}, {implement}>", service, implement);
        }

        foreach (var (service, implement) in EnumerateServcieTypes<SingletonServiceRegistoartionAttribute>())
        {
            servies.Add(ServiceDescriptor.Scoped(service, implement));
            logger.LogDebug(".AddScoped<{service}, {implement}>", service, implement);
        }

        return servies;
    }

    private static IEnumerable<(Type, Type)> EnumerateServcieTypes<TAttribute>()
        where TAttribute : ServiceRegistoartionAttribute
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var types = assembly.GetTypes()
                            .Select(t => (Attribute: t.GetCustomAttribute<TAttribute>(), ImplementType: t))
                            .Where(x => x.Attribute?.Enabled ?? false)
                            .Select(x => (x.Attribute!.ServiceType, x.ImplementType));

            foreach (var tuple in types)
            {
                yield return tuple;
            }
        }
    }

}
