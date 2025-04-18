//1. Crear la clase ServiceLifetimeAttribute detro del ensamblado donde estan las interfaces

//Ejemplo

using Microsoft.Extensions.DependencyInjection;

namespace GSM.Data.Interfaces
{
    [AttributeUsage(AttributeTargets.Interface, Inherited = false)]
    public class ServiceLifetimeAttribute: Attribute
    {
        public ServiceLifetime Lifetime { get;}

        public ServiceLifetimeAttribute(ServiceLifetime lifetime)
        {
            this.Lifetime = lifetime;
        }
    }
}
// 2. Crear una interface Base y asignar, ejemplo:


public interface IBaseAssembly {

}

public class BaseAssembly : IBaseAssembly{

}

// 3. A toda interface que se cree se le agregara el atributo del ServiceLifetime, definiendo el tipo de vida del servicio.
// Ejemplo.

[ServiceLifetime(ServiceLifetime.Scoped)]
public interface IExampleRepository
{

}

// 4. Agregar el codigo que escanea y agrega los servicios
// Es necesario agregar la bliblioteca de clases como referencia de proyecto en su proyecto actual que se esta trabajando (blazor en este caso)
public static class ServiceExtensions
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
                .FirstOrDefault();

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
    

// 5. Agregar el emsamblado al metodo que escanea los servicios.

 var TypeAssembly = typeof(IBaseAssembly).Assembly;

 builder.Services.ConfigureDataLayerServices(TypeAssembly);


 // Con eso se agregan en automatico todos los servicios
 
