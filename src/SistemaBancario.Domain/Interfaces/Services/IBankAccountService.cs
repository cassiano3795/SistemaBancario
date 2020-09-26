using System;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Interfaces.Services
{
    public interface IBankAccountService
    {
         void Withdraw(BankAccountModel bankAccountModel, double value);
         void Deposit(BankAccountModel bankAccountModel, double value);
         void Pay(BankAccountModel bankAccountModel, double value, string Description);
    }
}
