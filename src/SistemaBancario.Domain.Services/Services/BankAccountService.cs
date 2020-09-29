using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Enums;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Models;
using SistemaBancario.Domain.Observers.Transactions;
using SistemaBancario.Domain.Strategies.BankAccount;

namespace SistemaBancario.Domain.Services
{
    public class BankAccountService : BaseService<BankAccountModel>, IBankAccountService
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly TransactionObservable _transactionObservable;

        public BankAccountService(IMapper mapper, IBankAccountRepository bankAccountRepository, TransactionObservable transactionObservable)
            : base(bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
            _transactionObservable = transactionObservable;
        }

        public async Task<bool> WithdrawAsync(BankAccountWithdrawDto bankAccount)
        {
            var model = await _bankAccountRepository.SelectAsync(bankAccount.Id);
            var result = model.Withdraw(bankAccount.Value);

            if (result)
            {
                result = await _bankAccountRepository.SaveChangesAsync();
                var transaction = new TransactionModel
                {
                    BankAccountId = bankAccount.Id,
                    TransactionType = TransactionEnum.Withdraw,
                    Value = bankAccount.Value,
                    Description = TransactionEnum.Withdraw.Description()
                };

                _transactionObservable.Notify(transaction);
                return result;
            }

            return result;
        }
        public async Task<bool> DepositAsync(BankAccountDepositDto bankAccount)
        {
            var model = await _bankAccountRepository.SelectAsync(bankAccount.Id);
            model.Deposit(bankAccount.Value);
            var result = await _bankAccountRepository.SaveChangesAsync();

            if (result)
            {
                var transaction = new TransactionModel
                {
                    BankAccountId = bankAccount.Id,
                    TransactionType = TransactionEnum.Deposit,
                    Value = bankAccount.Value,
                    Description = TransactionEnum.Deposit.Description()
                };

                _transactionObservable.Notify(transaction);
                return result;
            }

            return result;
        }
        public async Task<bool> PayAsync(BankAccountPayDto bankAccount)
        {
            var model = await _bankAccountRepository.SelectAsync(bankAccount.Id);
            var result = model.Pay(bankAccount.Value);

            if (result)
            {
                result = await _bankAccountRepository.SaveChangesAsync();
                var transaction = new TransactionModel
                {
                    BankAccountId = bankAccount.Id,
                    TransactionType = TransactionEnum.Payment,
                    Value = bankAccount.Value,
                    Description = TransactionEnum.Payment.Description()
                };

                _transactionObservable.Notify(transaction);
                return result;
            }

            return result;
        }
    }
}
