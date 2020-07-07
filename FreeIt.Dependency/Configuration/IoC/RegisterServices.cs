using FreeIt.Dependency.Configuration.CustomServices;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.Dependency.Configuration.IoC
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
            => services
                .RegisterLowLevelServices();
    }
}