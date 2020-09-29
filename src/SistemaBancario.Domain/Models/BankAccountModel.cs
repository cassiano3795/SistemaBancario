using System.Collections.Generic;

namespace SistemaBancario.Domain.Models
{
    public class BankAccountModel : BaseModel
    {
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; private set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<TransactionModel> Transactions { get; set; }
        public virtual ICollection<BankAccountDailyInfoModel> DailyInfos { get; set; }

        private bool CheckBalance(double value) => Balance - value >= 0 ? true : false;

        /// <summary>
        /// Represents the action of withdrawing money from an account. 
        /// </summary>
        /// <param name="value">Withdrawal amount.</param>
        /// <returns></returns>
        public bool Withdraw(double value)
        {
            if (CheckBalance(value))
            {
                Balance -= value;
                return true;
            }

            return false;

        }

        /// <summary>
        /// Represents the action of depositing money from an account.
        /// </summary>
        /// <param name="value">Deposit amount.</param>
        /// <returns></returns>
        public void Deposit(double value)
        {
            Balance += value;
            return;
        }

        /// <summary>
        /// Represents the action of paying using the account balance.
        /// </summary>
        /// <param name="value">Payment amount.</param>
        /// <returns></returns>
        public bool Pay(double value)
        {
            if (CheckBalance(value))
            {
                Balance -= value;
                return true;
            }

            return false;
        }
    }
}
