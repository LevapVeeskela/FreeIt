using FreeIt.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using FreeIt.Dependency.Configuration.IoC;
using System.Threading.Tasks;

namespace FreeIt.LowLevel.FourthWeek
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
            => await Execute();

        static async Task Execute()
        {
            RegisterServices(new ServiceCollection());

            var service = _serviceProvider.GetService<IFourthWeekService>();

            await service.Process();

            Console.ReadKey();

            DisposeServices();
        }

        static void RegisterServices(IServiceCollection services)
        {
            services.RegisterServices();

            _serviceProvider = services.BuildServiceProvider();
        }

        static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
