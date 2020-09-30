using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Validation;

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

        public Task<BankAccountViewModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BankAccountViewModel>> GetAllAsync()
        {
            var listBankAccount = _mapper.Map<IList<BankAccountViewModel>>(await _bankAccountRepository.SelectAllAsync());
            return listBankAccount;
        }

        public async Task<BankAccountWithTransactionsViewModel> GetBankAccountWithTransactionsAndInfosByIdAsync(Guid id)
        {
            var banckAccountViewModel = _mapper
                .Map<BankAccountWithTransactionsViewModel>(await _bankAccountRepository.SelectWithTransactionsAndInfosByIdAsync(id));
            
            return banckAccountViewModel;
        }

        public async Task<IValidationResult> WithdrawAsync(BankAccountWithdrawViewModel bankAccount)
        {
            var id = new Guid("1d10e7a5-0fd5-4e48-b0b5-4dd97ad1fd7e");
            var bankAccountDto = _mapper.Map<BankAccountWithdrawDto>(bankAccount);
            bankAccountDto.Id = id;
            var result = await _bankAccountService.WithdrawAsync(bankAccountDto);

            return result;
        }

        public async Task<IValidationResult> DepositAsync(BankAccountDepositViewModel bankAccount)
        {
            var id = new Guid("1d10e7a5-0fd5-4e48-b0b5-4dd97ad1fd7e");
            var bankAccountDto = _mapper.Map<BankAccountDepositDto>(bankAccount);
            bankAccountDto.Id = id;
            var result = await _bankAccountService.DepositAsync(bankAccountDto);

            return result;
        }

        public async Task<IValidationResult> PayAsync(BankAccountPayViewModel bankAccount)
        {
            var id = new Guid("1d10e7a5-0fd5-4e48-b0b5-4dd97ad1fd7e");
            var bankAccountDto = _mapper.Map<BankAccountPayDto>(bankAccount);
            bankAccountDto.Id = id;
            var result = await _bankAccountService.PayAsync(bankAccountDto);

            return result;
        }

        
    }
}
