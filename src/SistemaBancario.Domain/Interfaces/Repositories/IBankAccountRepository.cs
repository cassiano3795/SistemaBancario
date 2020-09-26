using System;
using System.Threading.Tasks;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Interfaces.Repositories
{
    public interface IBankAccountRepository : IRepository<BankAccountModel>
    {
         Task<BankAccountWithTransactionsDto> GetBankAccountWithTransactionsByIdAsync(Guid id);
    }
}
