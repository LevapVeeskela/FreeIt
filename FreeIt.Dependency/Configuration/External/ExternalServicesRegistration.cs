using FreeIt.Domain.Interfaces.Services.External;
using FreeIt.Domain.Services.LowLevel.FourthWeek.External;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.Dependency.Configuration.External
{
    public static class ExternalServicesRegistration
    {
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services)
            => services
                .AddScoped<IQueryBuilder, QueryBuilder>()
                .AddScoped<IMillionaireClient, MillionaireClient>();
    }
}