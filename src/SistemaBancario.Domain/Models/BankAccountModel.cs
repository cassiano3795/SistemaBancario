using System.Collections.Generic;
using System.Reflection.Metadata;
using SistemaBancario.Domain.Validation;

namespace SistemaBancario.Domain.Models
{
    public class BankAccountModel : BaseModel
    {
        public string Name { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; private set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<TransactionModel> Transactions { get; set; }
        public virtual ICollection<BankAccountDailyInfoModel> DailyInfos { get; set; }

        private IValidationResult CheckBalance(double value)
        {
            var validationResult = new ValidationResult();
            if (Balance - value < 0)
            {
                validationResult.AddError("Saldo insuficiente");
            }

            return validationResult;
        }

        private IValidationResult CheckValueOperation(double value)
        {
            var validationResult = new ValidationResult();
            if (value <= 0)
            {
                validationResult.AddError("Valor deve ser maior que 0");
            }

            return validationResult;
        }

        /// <summary>
        /// Represents the action of withdrawing money from an account. 
        /// </summary>
        /// <param name="value">Withdrawal amount.</param>
        /// <returns></returns>
        public IValidationResult Withdraw(double value)
        {
            var result = CheckBalance(value);
            if (result.IsValid)
            {
                Balance -= value;
            }

            return result;

        }

        /// <summary>
        /// Represents the action of depositing money from an account.
        /// </summary>
        /// <param name="value">Deposit amount.</param>
        /// <returns></returns>
        public IValidationResult Deposit(double value)
        {
            var result = CheckValueOperation(value);
            if (result.IsValid)
            {
                Balance += value;
            }

            return result;
        }

        /// <summary>
        /// Represents the action of paying using the account balance.
        /// </summary>
        /// <param name="value">Payment amount.</param>
        /// <returns></returns>
        public IValidationResult Pay(double value)
        {
            var result = CheckBalance(value);
            if (result.IsValid)
            {
                Balance -= value;
            }

            return result;
        }
    }
}
