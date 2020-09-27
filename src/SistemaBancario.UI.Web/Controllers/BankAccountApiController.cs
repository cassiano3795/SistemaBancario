using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Application.ViewModels.BankAccount;

namespace SistemaBancario.UI.Web.Controllers
{
    [ApiController]
    [Route("api/BankAccount")]
    public class BankAccountApiController : ControllerBase
    {
        private readonly IBankAccountAppService _bankAccountAppService;

        public BankAccountApiController(IBankAccountAppService bankAccountAppService)
        {
            _bankAccountAppService = bankAccountAppService;
        }

        [HttpPost]
        [Route("withdraw")]
        public async Task<bool> WithdrawAsync(BankAccountWithdrawViewModel bankAccount)
        {
            if (!ModelState.IsValid)
                return false;

            var result = await _bankAccountAppService.WithdrawAsync(bankAccount);
            return result;
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<bool> DepositAsync(BankAccountDepositViewModel bankAccount)
        {
            if (!ModelState.IsValid)
                return false;

            var result = await _bankAccountAppService.DepositAsync(bankAccount);
            return result;
        }

        [HttpPost]
        [Route("pay")]
        public async Task<bool> PayAsync(BankAccountPayViewModel bankAccount)
        {
            if (!ModelState.IsValid)
                return false;

            var result = await _bankAccountAppService.PayAsync(bankAccount);
            return result;
        }
    }
}
