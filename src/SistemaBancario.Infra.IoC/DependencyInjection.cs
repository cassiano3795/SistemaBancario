using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Infra.Data.Configurations;
using SistemaBancario.Domain.Configurations;
using SistemaBancario.Application.Configurations;

namespace SistemaBancario.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            // ADD DBCONTEXT
            services.AddDataBaseConfiguration(configuration);

            // ADD REPOSITORIES
            services.AddRepositories();

            // ADD DOMAIN SERVICES
            services.AddDomainServices();

            // ADD DOMAIN OBSERVERS
            var provider = services.BuildServiceProvider();
            services.AddObservers(provider);

            // ADD APP SERVICES
            services.AddAppServices();

            // ADD AUTOMAPPER
            services.AddAutoMapperConfiguration();
        }
    }
}
