using System;

namespace SistemaBancario.Domain.Models
{
    public class BankAccountDailyInfoModel : BaseModel
    {
        public double BalanceAtDate { get; set; }
        public double IncomeBalance { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Guid BankAccountId { get; set; }
        public virtual BankAccountModel BankAccount { get; set; }
    }
}
