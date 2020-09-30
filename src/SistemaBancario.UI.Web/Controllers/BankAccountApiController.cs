using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Domain.Validation;

namespace SistemaBancario.UI.Web.Controllers
{
    [Route("api/BankAccount")]
    public class BankAccountApiController : BaseApiController
    {
        private readonly IBankAccountAppService _bankAccountAppService;

        public BankAccountApiController(IBankAccountAppService bankAccountAppService)
        {
            _bankAccountAppService = bankAccountAppService;
        }

        [HttpPost]
        [Route("withdraw")]
        public async Task<ActionResult<IValidationResult>> WithdrawAsync(BankAccountWithdrawViewModel bankAccount)
        {
            var result = await _bankAccountAppService.WithdrawAsync(bankAccount);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<ActionResult<IValidationResult>> DepositAsync(BankAccountDepositViewModel bankAccount)
        {
            var result = await _bankAccountAppService.DepositAsync(bankAccount);
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("pay")]
        public async Task<ActionResult<IValidationResult>> PayAsync(BankAccountPayViewModel bankAccount)
        {
            var result = await _bankAccountAppService.PayAsync(bankAccount);
            return CustomResponse(result);
        }
    }
}
