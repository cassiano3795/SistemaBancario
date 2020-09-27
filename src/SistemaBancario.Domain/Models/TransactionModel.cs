using System;
using SistemaBancario.Domain.Enums;

namespace SistemaBancario.Domain.Models
{
    public class TransactionModel : BaseModel
    {
        public TransactionModel()
            :base()
        {
            
        }
        public double Value { get; set; }
        public string Description { get; set; }
        public TransactionEnum TransactionType { get; set; }

        public Guid BankAccountId { get; set; }
        public virtual BankAccountModel BankAccount { get; set; }
    }
}
