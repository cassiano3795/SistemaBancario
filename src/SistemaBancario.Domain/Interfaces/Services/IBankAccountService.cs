using System;
using System.Threading.Tasks;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Interfaces.Services
{
    public interface IBankAccountService : IService<BankAccountModel>
    {
         Task<bool> WithdrawAsync(BankAccountWithdrawDto bankAccount);
         Task<bool> DepositAsync(BankAccountDepositDto bankAccount);
         Task<bool> PayAsync(BankAccountPayDto bankAccount);
    }
}
