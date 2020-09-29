using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Strategies.BankAccount
{
    public interface IIncomeStrategy
    {
         double ApplyIncome(BankAccountModel bankAccount);
    }
}
