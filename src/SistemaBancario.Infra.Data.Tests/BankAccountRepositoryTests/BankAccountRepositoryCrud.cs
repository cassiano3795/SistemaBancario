using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Models;
using SistemaBancario.Infra.Data.Context;
using SistemaBancario.Infra.Data.Repositories;
using SistemaBancario.Infra.Data.Tests.Configurations;
using Xunit;

namespace SistemaBancario.Infra.Data.Tests.BankAccountRepositoryTests
{
    public class BankAccountRepositoryCrud : IClassFixture<DbTestConfiguration>
    {
        private IServiceProvider _serviceProvider;
        public BankAccountRepositoryCrud(DbTestConfiguration dbTestConfiguration)
        {
            _serviceProvider = dbTestConfiguration.ServiceProvider;
        }

        private BankAccountModel GetBankAccountModel()
        {
            var model = new BankAccountModel
            {
                Id = new Guid(),
                Name = Faker.Name.FullName(),
                Agency = 1,
                AccountNumber = 1
            };

            return model;
        }

        private async Task<Guid> CreateBankAccounAsync(double? balance = 0)
        {
            using (var bankAccountRepository = _serviceProvider.GetService<IBankAccountRepository>())
            {
                var model = GetBankAccountModel();
                if (balance > 0) model.Deposit(balance.Value);

                await bankAccountRepository.InsertAsync(model);
                await bankAccountRepository.SaveChangesAsync();

                return model.Id;
            }
        }

        [Fact]
        public async Task CreateBankAccount()
        {
            using (var bankAccountRepository = _serviceProvider.GetService<IBankAccountRepository>())
            {
                var model = GetBankAccountModel();

                await bankAccountRepository.InsertAsync(model);
                var result = await bankAccountRepository.SaveChangesAsync();

                Assert.True(result);
            }
        }

        [Theory]
        [InlineData(200)]
        [InlineData(650)]
        [InlineData(999)]
        public async Task GetBankAccount(double balance)
        {
            using (var bankAccountRepository = _serviceProvider.GetService<IBankAccountRepository>())
            {
                var id = await CreateBankAccounAsync(balance);

                var model = await bankAccountRepository.SelectAsync(id);

                Assert.Equal(id, model.Id);
                Assert.Equal(balance, model.Balance);
            }
        }

        [Fact]
        public async Task RemoveBankAccount()
        {
            using (var bankAccountRepository = _serviceProvider.GetService<IBankAccountRepository>())
            {
                var id = await CreateBankAccounAsync();

                await bankAccountRepository.DeleteAsync(id);
                await bankAccountRepository.SaveChangesAsync();

                var modelDb = await bankAccountRepository.SelectAsync(id);
                Assert.Null(modelDb);
            }
        }

        [Fact]
        public async Task UpdateBankAccount()
        {
            using (var bankAccountRepository = _serviceProvider.GetService<IBankAccountRepository>())
            {
                var name = Faker.Name.FullName();
                var id = await CreateBankAccounAsync();

                var modelDb = await bankAccountRepository.SelectAsync(id);
                modelDb.Name = name;
                modelDb.Active = false;
                await bankAccountRepository.UpdateAsync(modelDb);
                await bankAccountRepository.SaveChangesAsync();
                modelDb = await bankAccountRepository.SelectAsync(id);

                Assert.Equal(name, modelDb.Name);
                Assert.False(modelDb.Active);
            }
        }
    }
}
