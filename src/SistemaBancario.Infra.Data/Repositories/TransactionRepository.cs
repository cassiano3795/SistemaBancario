using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Models;
using SistemaBancario.Infra.Data.Context;

namespace SistemaBancario.Infra.Data.Repositories
{
    public class TransactionRepository : BaseRepository<TransactionModel>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
