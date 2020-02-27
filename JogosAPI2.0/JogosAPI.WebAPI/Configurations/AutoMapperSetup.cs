using JogosAPI.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;

namespace JogosAPI.WebAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToModelMappingProfile), typeof(ModelToDomainMappingProfile));
        }
    }
}
