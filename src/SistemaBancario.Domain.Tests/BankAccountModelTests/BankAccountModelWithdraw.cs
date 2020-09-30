using System;
using SistemaBancario.Domain.Models;
using Xunit;

namespace SistemaBancario.Domain.Tests.BankAccountModelTests
{
    public class BankAccountModelWithdraw
    {
        private BankAccountModel GetBankAccountModel(double balance)
        {
            var model = new BankAccountModel
            {
                Id = new Guid(),
                Agency = 1,
                AccountNumber = 1
            };

            model.Deposit(balance);
            return model;
        }

        [Fact]
        public void SufficientFunds()
        {
            var model = new BankAccountModel{
                Id = new Guid(),
                Agency = 1,
                AccountNumber = 1
            };

            model.Deposit(200);
            var result = model.Withdraw(199);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void InsufficientFunds()
        {
            var model = new BankAccountModel{
                Id = new Guid(),
                Agency = 1,
                AccountNumber = 1
            };

            model.Deposit(200);
            var result = model.Withdraw(250);

            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(150)]
        [InlineData(125.85)]
        [InlineData(99.67)]
        public void CheckBalanceAfterWithdraw(double value)
        {
            var balance = 200;
            var model = GetBankAccountModel(balance);

            model.Withdraw(value);

            Assert.Equal(model.Balance, balance - value);
        }
    }
}
