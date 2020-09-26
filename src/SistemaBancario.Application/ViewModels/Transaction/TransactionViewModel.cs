using SistemaBancario.Domain.Enums;

namespace SistemaBancario.Application.ViewModels.Transaction
{
    public class TransactionViewModel
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public TransactionEnum TransactionType { get; set; }
    }
}
