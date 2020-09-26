using System;
using System.Threading.Tasks;
using AutoMapper;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Interfaces.Services;

namespace SistemaBancario.Application.Services
{
    public class BankAccountAppService : IBankAccountAppService
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountService _bankAccountService;
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountAppService(IMapper mapper, IBankAccountService bankAccountService, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountService = bankAccountService;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<BankAccountViewModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BankAccountWithTransactionsViewModel> GetBankAccountWithTransactionsByIdAsync(Guid id)
        {
            var banckAccountViewModel = _mapper
                .Map<BankAccountWithTransactionsViewModel>(await _bankAccountRepository.GetBankAccountWithTransactionsByIdAsync(id));
            
            return banckAccountViewModel;
        }
    }
}
