using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Application.AutoMapper;

namespace SistemaBancario.Application.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DtoToViewModelMappingProfile), typeof(ModelToViewModelMappingProfile));
        }
    }
}
