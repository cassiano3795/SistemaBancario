using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBancario.Application.ViewModels.BankAccount
{
    public class BankAccountWithdrawViewModel
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor de retirada precisa ser maior que 0")]
        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
}
