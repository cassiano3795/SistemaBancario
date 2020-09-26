using AutoMapper;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Application.ViewModels.Transaction;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Dtos.Transaction;

namespace SistemaBancario.Application.AutoMapper
{
    public class DtoToViewModelMappingProfile : Profile
    {
        public DtoToViewModelMappingProfile()
        {
            CreateMap<BankAccountDto, BankAccountViewModel>();
            CreateMap<BankAccountWithTransactionsDto, BankAccountWithTransactionsViewModel>();

            CreateMap<TransactionDto, TransactionViewModel>();
        }
    }
}
