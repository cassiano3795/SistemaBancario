using System;
using SistemaBancario.Domain.Enums;

namespace SistemaBancario.Domain.Models
{
    public class TransactionModel : BaseModel
    {
        public string Description { get; set; }
        // public DateTime TransationDate{ get; set; }
        public TransactionEnum TransactionType { get; set; }

        public Guid BankAccountId { get; set; }
        public virtual BankAccountModel BankAccount { get; set; }
    }
}
