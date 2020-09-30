using System;
using SistemaBancario.Domain.Models;
using Xunit;

namespace SistemaBancario.Domain.Tests.BankAccountModelTests
{
    public class BankAccountModelPay
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

        [Theory]
        [InlineData(199.99)]
        [InlineData(199)]
        [InlineData(150)]
        [InlineData(1)]
        public void SufficientFunds(double value)
        {
            var balance = 200;
            var model = GetBankAccountModel(balance);

            var result = model.Pay(value);

            Assert.True(result.IsValid);
        }


        [Theory]
        [InlineData(250)]
        [InlineData(200.01)]
        [InlineData(200.10)]
        [InlineData(999)]
        public void InsificientFunds(double value)
        {
            var balance = 200;
            var model = GetBankAccountModel(balance);

            var result = model.Pay(value);

            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(150)]
        [InlineData(125.85)]
        [InlineData(99.67)]
        public void CheckBalanceAfterPay(double value)
        {
            var balance = 200;
            var model = GetBankAccountModel(balance);

            model.Pay(value);

            Assert.Equal(model.Balance, balance - value);
        }
    }
}
