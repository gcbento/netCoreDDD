using AutoMapper;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Entities;

namespace JogosAPI.Application.AutoMapper
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            //CreateMap<GameModel, RegisterNewCustomerCommand>()
            //    .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            //CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //    .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<BaseModel, BaseEntity>();
            CreateMap<GameModel, Game>();
        }
    }
}
