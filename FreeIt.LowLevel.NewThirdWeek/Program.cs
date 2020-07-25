using FreeIt.Domain.Interfaces.Services;
using System;
using FreeIt.Dependency.Configuration.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.LowLevel.NewThirdWeek
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
            => Execute();

        static void Execute()
        {
            RegisterServices(new ServiceCollection());

            var service = _serviceProvider.GetService<INewThirdWeekService>();

            service.Process();

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
