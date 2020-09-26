using System.ComponentModel;

namespace SistemaBancario.Domain.Enums
{
    public enum TransactionEnum
    {
        [Description("Retirada")]
        Withdraw,

        [Description("Deposito")]
        Deposit,

        [Description("Pagamento")]
        Payment
    }
}
