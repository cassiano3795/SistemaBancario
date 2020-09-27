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
            CreateMap<BankAccountDto, BankAccountViewModel>().ReverseMap();
            CreateMap<BankAccountWithdrawDto, BankAccountWithdrawViewModel>().ReverseMap();
            CreateMap<BankAccountDepositDto, BankAccountDepositViewModel>().ReverseMap();
            CreateMap<BankAccountPayDto, BankAccountPayViewModel>().ReverseMap();
            CreateMap<BankAccountWithTransactionsDto, BankAccountWithTransactionsViewModel>().ReverseMap();

            CreateMap<TransactionDto, TransactionViewModel>().ReverseMap();
        }
    }
}
