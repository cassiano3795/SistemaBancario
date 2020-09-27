using System;
using System.Threading.Tasks;
using SistemaBancario.Application.ViewModels.BankAccount;

namespace SistemaBancario.Application.Interfaces
{
    public interface IBankAccountAppService
    {
        Task<BankAccountViewModel> GetByIdAsync(Guid id);
        Task<BankAccountWithTransactionsViewModel> GetBankAccountWithTransactionsByIdAsync(Guid id);
        Task<bool> WithdrawAsync(BankAccountWithdrawViewModel bankAccount);
        Task<bool> DepositAsync(BankAccountDepositViewModel bankAccount);
        Task<bool> PayAsync(BankAccountPayViewModel bankAccount);
    }
}
