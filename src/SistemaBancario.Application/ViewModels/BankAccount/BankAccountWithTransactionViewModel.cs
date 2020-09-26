using System.Collections.Generic;
using SistemaBancario.Application.ViewModels.Transaction;

namespace SistemaBancario.Application.ViewModels.BankAccount
{
    public class BankAccountWithTransactionsViewModel
    {
        public BankAccountViewModel BankAccount { get; set; }
        public IList<TransactionViewModel> Transactions { get; set; }
    }
}
