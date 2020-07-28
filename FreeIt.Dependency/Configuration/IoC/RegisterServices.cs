using FreeIt.Dependency.Configuration.CustomServices;
using FreeIt.Dependency.Configuration.External;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.Dependency.Configuration.IoC
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
            => services
                .RegisterLowLevelServices()
                .RegisterExternalServices();
    }
}