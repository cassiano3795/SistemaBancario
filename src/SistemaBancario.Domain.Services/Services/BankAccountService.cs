using System;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Services
{
    public class BankAccountService : BaseService<BankAccountModel>, IBankAccountService
    {
        public void Withdraw(BankAccountModel bankAccountModel, double value)
        {
            var result = bankAccountModel.Withdraw(value);
            // TODO: NOTIFY OBSERVERS
            throw new NotImplementedException();
        }
        public void Deposit(BankAccountModel bankAccountModel, double value)
        {
            var result = bankAccountModel.Deposit(value);
            // TODO: NOTIFY OBSERVERS
            throw new NotImplementedException();
        }
        public void Pay(BankAccountModel bankAccountModel, double value, string description)
        {
            var result = bankAccountModel.Pay(value, description);
            // TODO: NOTIFY OBSERVERS
            throw new NotImplementedException();
        }
    }
}
