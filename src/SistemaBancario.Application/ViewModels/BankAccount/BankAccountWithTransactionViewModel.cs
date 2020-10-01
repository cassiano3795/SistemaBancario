using System;
using System.Collections.Generic;
using SistemaBancario.Application.ViewModels.Transaction;

namespace SistemaBancario.Application.ViewModels.BankAccount
{
    public class BankAccountWithTransactionsViewModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; private set; }
        public IList<TransactionViewModel> Transactions { get; set; }
        public IList<BankAccountDailyInfoViewModel> DailyInfos { get; set; }
    }
}
