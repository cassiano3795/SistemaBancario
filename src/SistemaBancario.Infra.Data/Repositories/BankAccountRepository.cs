using System.Linq;
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
    }
}
