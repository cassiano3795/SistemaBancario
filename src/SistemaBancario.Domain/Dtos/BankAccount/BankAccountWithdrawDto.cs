using System;

namespace SistemaBancario.Domain.Dtos.BankAccount
{
    public class BankAccountWithdrawDto
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
    }
}
