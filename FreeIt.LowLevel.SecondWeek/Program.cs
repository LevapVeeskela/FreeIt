using System;
using FreeIt.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using FreeIt.Dependency.Configuration.IoC;

namespace FreeIt.LowLevel.SecondWeek
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
            => Execute();

        static void Execute()
        {
            RegisterServices(new ServiceCollection());

            var service = _serviceProvider.GetService<ISecondWeekService>();

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
