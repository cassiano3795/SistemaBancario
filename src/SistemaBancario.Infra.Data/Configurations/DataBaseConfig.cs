using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Infra.Data.Context;
using SistemaBancario.Infra.Data.Repositories;

namespace SistemaBancario.Infra.Data.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<AppDbContext>(options => 
                options.UseMySql(configuration.GetConnectionString("sistemabancario")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
