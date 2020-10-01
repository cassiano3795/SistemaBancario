using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Infra.Data.Configurations;
using SistemaBancario.Infra.Data.Context;

namespace SistemaBancario.Infra.Data.Tests.Configurations
{
    public class DbTestConfiguration : IDisposable
    {
        private string _dataBaseName = "dbSistemaBancarioTeste";
        public IServiceProvider ServiceProvider { get; set; }

        public DbTestConfiguration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase(_dataBaseName),
                ServiceLifetime.Scoped);

            serviceCollection.AddRepositories();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {

        }
    }
}
