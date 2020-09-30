using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Domain.Validation;

namespace SistemaBancario.UI.Web.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IValidationResult _validationResult = new ValidationResult();
        protected ActionResult CustomResponse(object result = null)
        {
            if (_validationResult.IsValid)
            {
                _validationResult.Data = result;
                return Ok(_validationResult);
            }

            return BadRequest(_validationResult);
        }
        protected ActionResult CustomResponse(IValidationResult validationResult)
        {
            _validationResult = validationResult;

            return CustomResponse();
        }
    }
}
