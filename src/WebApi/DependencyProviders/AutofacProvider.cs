using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models;

namespace WebApi.DependencyProviders
{
    public static class AutofacProvider
    {
        public static IServiceProvider Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterType<SingletonScope>().SingleInstance();
            builder.RegisterType<ScopedScope>().InstancePerLifetimeScope();
            builder.RegisterType<TransientScope>().InstancePerDependency();
            builder.RegisterType<ScopeFactory>().InstancePerLifetimeScope();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}