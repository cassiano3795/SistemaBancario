using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Dtos.Transaction;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Models;
using SistemaBancario.Infra.Data.Context;

namespace SistemaBancario.Infra.Data.Repositories
{
    public class BankAccountRepository : BaseRepository<BankAccountModel>, IBankAccountRepository 
    {
        public BankAccountRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<BankAccountWithTransactionsDto> GetBankAccountWithTransactionsByIdAsync(Guid id)
        {
            try
            {
                var bankAccount = await _set.Include(x => x.Transactions).Where(x => x.Id == id).Select(s => new BankAccountWithTransactionsDto{
                    BankAccount = new BankAccountDto{
                        Id = s.Id,
                        Agency = s.Agency,
                        AccountNumber = s.AccountNumber,
                        Balance = s.Balance
                    },
                    Transactions = s.Transactions.Select(t => new TransactionDto{
                        Description = t.Description,
                        TransactionType = t.TransactionType,
                        CreatedAt = t.CreatedAt,
                        Value = t.Value
                    }).OrderByDescending(o => o.CreatedAt).ToList()
                }).FirstOrDefaultAsync();

                return bankAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
