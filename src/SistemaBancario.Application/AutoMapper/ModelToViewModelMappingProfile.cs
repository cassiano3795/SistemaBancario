using AutoMapper;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Application.ViewModels.Transaction;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            // BANK ACCOUNT
            CreateMap<BankAccountModel, BankAccountViewModel>().ReverseMap();
            CreateMap<BankAccountModel, BankAccountWithTransactionsViewModel>();

            // TRANSACTION
            CreateMap<TransactionModel, TransactionViewModel>().ReverseMap();
        }
    }
}
