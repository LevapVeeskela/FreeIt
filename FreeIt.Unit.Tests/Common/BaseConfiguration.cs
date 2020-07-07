using System;
using FreeIt.Dependency.Configuration.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace FreeIt.Unit.Tests.Common
{
    public class BaseConfiguration
    {
        public IServiceProvider _serviceProvider;

        public BaseConfiguration() 
            => RegisterServices(new ServiceCollection());

        private void RegisterServices(IServiceCollection services)
        {
            services.RegisterServices();

            _serviceProvider = services.BuildServiceProvider();
        }

        public void DisposeServices()
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