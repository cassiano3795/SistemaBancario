using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Strategies.BankAccount
{
    public class BankAccountIncomeStrategy : IIncomeStrategy
    {
        private const double percent = 0.0013;
        public double ApplyIncome(BankAccountModel bankAccount)
        {
            if (bankAccount.Balance == 0)
                return 0;


            var income = bankAccount.Balance * percent;
            return income;
        }
    }
}
