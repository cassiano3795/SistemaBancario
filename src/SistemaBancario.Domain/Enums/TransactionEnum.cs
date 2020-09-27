using System.ComponentModel;

namespace SistemaBancario.Domain.Enums
{
    public enum TransactionEnum
    {
        [Description("Retirada")]
        Withdraw,

        [Description("Depósito")]
        Deposit,

        [Description("Pagamento")]
        Payment
    }
}
