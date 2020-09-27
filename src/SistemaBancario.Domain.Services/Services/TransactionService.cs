using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Services.Services
{
    public class TransactionService : BaseService<TransactionModel>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
            :base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
    }
}
