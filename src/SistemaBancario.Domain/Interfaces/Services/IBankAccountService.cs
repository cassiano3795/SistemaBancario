using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Models;
using SistemaBancario.Domain.Validation;

namespace SistemaBancario.Domain.Interfaces.Services
{
    public interface IBankAccountService : IService<BankAccountModel>
    {
        Task<IValidationResult> WithdrawAsync(BankAccountWithdrawDto bankAccount);
        Task<IValidationResult> DepositAsync(BankAccountDepositDto bankAccount);
        Task<IValidationResult> PayAsync(BankAccountPayDto bankAccount);
    }
}
