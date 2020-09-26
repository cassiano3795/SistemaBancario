using System;

namespace SistemaBancario.Domain.Dtos.BankAccount
{
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
    }
}
