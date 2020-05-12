using JogosAPI.Infra.CrossCutting.IoC;
using JogosAPI.WebAPI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JogosAPI.WebAPI.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
