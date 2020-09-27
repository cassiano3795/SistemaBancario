using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBancario.Application.ViewModels.BankAccount
{
    public class BankAccountPayViewModel
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor de pagamento precisa ser maior que 0")]
        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
}
