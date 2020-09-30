using System.Collections;
using System.Collections.Generic;

namespace SistemaBancario.Domain.Validation
{
    public interface IValidationResult
    {
        Error Errors { get; }
        object Data { get; set;}
        bool IsValid { get; }
        void AddError(string error);
    }
}
