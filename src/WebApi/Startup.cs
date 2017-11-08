using System;
using Autofac.Extensions.DependencyInjection;
using WebApi.DependencyProviders;
using WebApi.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutofac();

            return ConfigureProviderByDependency(services);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        private IServiceProvider ConfigureProviderByDependency(IServiceCollection services)
        {
            var provider = Configuration.GetValue<DependencyProvider>("DependencyProvider");

            switch (provider)
            {
                case DependencyProvider.Autofac:
                    return AutofacProvider.Configure(services);
                case DependencyProvider.DotNet:
                    return DotNetProvider.Configure(services);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
