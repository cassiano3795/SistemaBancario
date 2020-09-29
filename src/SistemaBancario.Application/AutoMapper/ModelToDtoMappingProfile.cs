using AutoMapper;
using SistemaBancario.Domain.Dtos.BankAccount;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Application.AutoMapper
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<BankAccountModel, BankAccountDto>().ReverseMap();
        }
    }
}
