using System;

namespace SistemaBancario.Application.ViewModels.BankAccount
{
    public class BankAccountDailyInfoViewModel
    {
        public double BalanceAtDate { get; set; }
        public double IncomeBalance { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Guid BankAccountId { get; set; }
    }
}
