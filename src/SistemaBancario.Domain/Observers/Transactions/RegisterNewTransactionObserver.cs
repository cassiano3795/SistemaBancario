using System;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Observers.Transactions
{
    public class RegisterNewTransactionObserver : AbastractObserver<TransactionModel>
    {
        private readonly ITransactionService _transactionService;

        public RegisterNewTransactionObserver(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(TransactionModel value)
        {
            _transactionService.CreateAsync(value);
        }
    }
}
