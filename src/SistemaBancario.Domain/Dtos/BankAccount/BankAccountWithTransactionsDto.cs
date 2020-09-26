using System.Collections.Generic;
using SistemaBancario.Domain.Dtos.Transaction;

namespace SistemaBancario.Domain.Dtos.BankAccount
{
    public class BankAccountWithTransactionsDto
    {
        public BankAccountDto BankAccount { get; set; }
        public IList<TransactionDto> Transactions { get; set; }
    }
}
