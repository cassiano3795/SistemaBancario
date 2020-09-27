using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Observers.Transactions;
using SistemaBancario.Domain.Services;
using SistemaBancario.Domain.Services.Services;

namespace SistemaBancario.Domain.Configurations
{
    public static class DomainServicesConfig
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // ADD SERVICES
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }

        public static void AddObservers(this IServiceCollection services, IServiceProvider provider)
        {
            // ADD OBSERVERS
            var transactionService = (ITransactionService)provider.GetService(typeof(ITransactionService));

            var registerNewTransactionObserver = new RegisterNewTransactionObserver(transactionService);
            var transactionObservable = new TransactionObservable();

            transactionObservable.Subscribe(registerNewTransactionObserver);

            services.AddSingleton(transactionObservable);
        }
    }
}
