﻿using FreeIt.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using FreeIt.Dependency.Configuration.IoC;
using FreeIt.Domain.Common.Enums;
using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Interfaces.Services.External;

namespace FreeIt.LowLevel.FourthWeek
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
            => Execute();

        static async void Execute()
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
