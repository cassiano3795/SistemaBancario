using System;
using System.Linq;
using SistemaBancario.Domain.Models;
using Xunit;

namespace SistemaBancario.Domain.Tests.BankAccountModelTests
{
    public class BankAccountModelDeposit
    {
         private BankAccountModel GetBankAccountModel()
        {
            var model = new BankAccountModel
            {
                Id = new Guid(),
                Agency = 1,
                AccountNumber = 1
            };

            return model;
        }

        [Theory]
        [InlineData(new double[] {200, 500})]
        [InlineData(new double[] {600, 1, 65.68})]
        [InlineData(new double[] {755, 852})]
        [InlineData(new double[] {958, 697})]
        [InlineData(new double[] {200, 457,36})]
        public void CheckBankAccountAfterDeposit(double[] values)
        {
            var model = GetBankAccountModel();

            foreach (var value in values)
            {
                model.Deposit(value);
            }

            Assert.Equal(model.Balance, values.Sum());
        }
    }
}
