using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Domain.Validation;

namespace SistemaBancario.Application.Interfaces
{
    public interface IBankAccountAppService
    {
        Task<IList<BankAccountViewModel>> GetAllAsync();
        Task<BankAccountViewModel> GetByIdAsync(Guid id);
        Task<BankAccountWithTransactionsViewModel> GetBankAccountWithTransactionsAndInfosByIdAsync(Guid id);
        Task<IValidationResult> WithdrawAsync(BankAccountWithdrawViewModel bankAccount);
        Task<IValidationResult> DepositAsync(BankAccountDepositViewModel bankAccount);
        Task<IValidationResult> PayAsync(BankAccountPayViewModel bankAccount);
    }
}
