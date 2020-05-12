using AutoMapper;
using JogosAPI.Application.Models;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using System.Collections.Generic;

namespace JogosAPI.Application.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<BaseEntity, BaseResponse>();
            CreateMap<Game, GameResponse>().ForMember(x => x.Accounts, opt => opt.Ignore());
            CreateMap<Account, AccountResponse>();
        }
    }
}
