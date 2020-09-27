using AutoMapper;
using SistemaBancario.Application.ViewModels.BankAccount;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<BankAccountModel, BankAccountViewModel>().ReverseMap();
        }
    }
}
