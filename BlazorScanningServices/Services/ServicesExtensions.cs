using System.Reflection;
using Services;

namespace BlazorScanningServices.InjectedServices
{
    public static class ServicesExtensions
    {
        public static void ConfigureDataLayerServices(this IServiceCollection services, Assembly assembly)
        {

            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .SelectMany(t => t.GetInterfaces(), (type, interfaceType) => new { type, interfaceType })
                .Where(t => t.interfaceType.GetCustomAttributes(typeof(ServiceLifetimeAttribute), false).Length > 0)
                .ToList();

            foreach (var service in serviceTypes)
            {
                var attribute = (ServiceLifetimeAttribute)service.interfaceType
                    .GetCustomAttributes(typeof(ServiceLifetimeAttribute), false)
                    .FirstOrDefault()!;

                if (attribute != null)
                {
                    switch (attribute.Lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(service.interfaceType, service.type);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(service.interfaceType, service.type);
                            break;
                        case ServiceLifetime.Scoped:
                        default:
                            services.AddScoped(service.interfaceType, service.type);
                            break;
                    }
                }
            }

        }

    }
}
