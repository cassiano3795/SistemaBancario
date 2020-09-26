using System;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Application.Services;

namespace SistemaBancario.Application.Configurations
{
    public static class AppServicesConfig
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IBankAccountAppService, BankAccountAppService>();
        }
    }
}
