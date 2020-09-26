using SistemaBancario.Domain.Enums;

namespace SistemaBancario.Domain.Dtos.Transaction
{
    public class TransactionDto
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public TransactionEnum TransactionType { get; set; }
    }
}
