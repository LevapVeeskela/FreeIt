using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FreeIt.Dependency.Configuration.IoC
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDependencyServices(
            this IServiceCollection services,
            IHostingEnvironment environment,
            IConfiguration configuration)
            => services
                .RegisterServices();
    }
}