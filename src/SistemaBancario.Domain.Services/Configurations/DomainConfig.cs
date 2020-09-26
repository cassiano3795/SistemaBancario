using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Services;

namespace SistemaBancario.Domain.Configurations
{
    public static class DomainConfig
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // ADD SERVICES
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<IBankAccountService, BankAccountService>();
        }
    }
}
