using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.UI.Web.Models;

namespace SistemaBancario.UI.Web.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IBankAccountAppService _accountAppService;
        private readonly ILogger<BankAccountController> _logger;

        public BankAccountController(ILogger<BankAccountController> logger, IBankAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var id = (await _accountAppService.GetAllAsync()).FirstOrDefault().Id;
            var bankAccountViewModel = await _accountAppService.GetBankAccountWithTransactionsByIdAsync(id);
            return View(bankAccountViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
