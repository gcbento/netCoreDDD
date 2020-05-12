using AutoMapper;
using JogosAPI.Application.Models;
using JogosAPI.Application.Models.Request;
using JogosAPI.Domain.Entities;
using System.Collections.Generic;

namespace JogosAPI.Application.AutoMapper
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            CreateMap<BaseRequest, BaseEntity>();
            CreateMap<GameRequest, Game>();
            CreateMap<AccountRequest, Account>();
            CreateMap<GameAccountRequest, GameAccount>();
        }
    }
}