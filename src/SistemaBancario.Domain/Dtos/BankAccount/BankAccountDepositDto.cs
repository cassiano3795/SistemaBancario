using System;

namespace SistemaBancario.Domain.Dtos.BankAccount
{
    public class BankAccountDepositDto
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
    }
}
