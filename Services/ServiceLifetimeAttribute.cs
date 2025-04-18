using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    [AttributeUsage(AttributeTargets.Interface, Inherited = false)]
    public class ServiceLifetimeAttribute: Attribute
    {
        public ServiceLifetime Lifetime { get; }

        public ServiceLifetimeAttribute(ServiceLifetime lifetime)
        {
            this.Lifetime = lifetime;
        }
    }
}
