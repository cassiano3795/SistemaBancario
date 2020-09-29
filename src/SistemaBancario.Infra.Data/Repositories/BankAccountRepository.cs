using System;
using System.Collections;
using System.Collections.Generic;
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

        public async Task<IList<BankAccountModel>> SelectAllActiveAsync()
        {
            try
            {
                
                var bankAccounts = await _set.Where(x => x.Active).ToListAsync();
                return bankAccounts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BankAccountModel> SelectWithTransactionsByIdAsync(Guid id)
        {
            try
            {
                var bankAccount = await _set.Include(x => x.Transactions)
                    .Where(x => x.Id == id && x.Active)
                    .FirstOrDefaultAsync();
                
                bankAccount.Transactions = bankAccount.Transactions.OrderByDescending(o => o.CreatedAt).ToList();

                return bankAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
