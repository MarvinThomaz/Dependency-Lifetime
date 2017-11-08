using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Models;

namespace WebApi.DependencyProviders
{
    public static class DotNetProvider
    {
        public static IServiceProvider Configure(IServiceCollection services)
        {
            services.AddSingleton<SingletonScope>();
            services.AddScoped<ScopedScope>();
            services.AddTransient<TransientScope>();
            services.AddScoped<ScopeFactory>();

            return services.BuildServiceProvider();
        }
    }
}