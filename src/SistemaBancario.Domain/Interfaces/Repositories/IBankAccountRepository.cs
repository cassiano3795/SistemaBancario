using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Interfaces.Repositories
{
    public interface IBankAccountRepository : IRepository<BankAccountModel>
    {
        Task<IList<BankAccountModel>> SelectAllActiveAsync();
        Task<BankAccountModel> SelectWithTransactionsByIdAsync(Guid id);
    }
}
