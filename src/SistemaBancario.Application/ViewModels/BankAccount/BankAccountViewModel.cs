using System;

namespace SistemaBancario.Application.ViewModels.BankAccount
{
    public class BankAccountViewModel
    {
        public Guid Id { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; private set; }
    }
}
