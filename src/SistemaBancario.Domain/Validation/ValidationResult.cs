using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBancario.Domain.Validation
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult()
        {
            Errors = new Error();
        }

        public Error Errors { get; }
        public bool IsValid => Errors.Value.Count == 0;
        public object Data { get; set; }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }

    public class Error
    {
        private readonly IList<string> _errors = new List<string>();

        [JsonPropertyName("Value")]
        public IList<string> Value => _errors;

        public void Add(string error)
        {
            _errors.Add(error);
        }
    }
}
