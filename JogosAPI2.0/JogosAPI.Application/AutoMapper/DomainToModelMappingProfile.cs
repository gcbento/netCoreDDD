using AutoMapper;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Entities;
using System.Collections.Generic;

namespace JogosAPI.Application.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<BaseEntity, BaseModel>();
            CreateMap<Game, GameModel>();
            //CreateMap<List<Game>, List<GameModel>>();
        }
    }
}
