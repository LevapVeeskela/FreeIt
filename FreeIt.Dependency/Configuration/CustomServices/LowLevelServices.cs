using FreeIt.Domain.Interfaces.Services;
using FreeIt.Domain.Services.LowLevel.FirstWeek;
using FreeIt.Domain.Services.LowLevel.FourthWeek;
using FreeIt.Domain.Services.LowLevel.NewThirdWeek;
using FreeIt.Domain.Services.LowLevel.SecondWeek;
using FreeIt.Domain.Services.LowLevel.ThirdWeek;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.Dependency.Configuration.CustomServices
{
    internal static class LowLevelServicesConfiguration
    {
        public static IServiceCollection RegisterLowLevelServices(this IServiceCollection services)
            => services
                .AddScoped<IFirstWeekService, FirstWeekService>()
                .AddScoped<ISecondWeekService, SecondWeekService>()
                .AddScoped<IThirdWeekService, ThirdWeekService>()
                .AddScoped<INewThirdWeekService, NewThirdWeekService>()
                .AddScoped<IFourthWeekService, FourthWeekService>();
    }
}