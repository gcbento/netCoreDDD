using AutoMapper;
using JogosAPI.Application.Models;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JogosAPI.Application.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<BaseEntity, BaseResponse>();

            CreateMap<Game, GameResponse>().ForMember(gameResponse => gameResponse.Accounts,
                                                                      opt => opt.MapFrom(game => game.Accounts.Select(x => new AccountResponse()
                                                                      {
                                                                          Id = x.Account.Id,
                                                                          Email = x.Account.Email,
                                                                          PassWord = x.Account.Password,
                                                                          OnlineId = x.Account.OnlineId,
                                                                          BirthDate = x.Account.BirthDate,
                                                                          DeactivationDate = x.Account.DeactivationDate
                                                                      })));

            CreateMap<Account, AccountResponse>().ForMember(accountResponse => accountResponse.Games,
                                                                      opt => opt.MapFrom(account => account.Games.Select(x => new GameResponse()
                                                                      {
                                                                          Id = x.Game.Id,
                                                                          Name = x.Game.Name,
                                                                          Completed = x.Game.Completed
                                                                      })));
            CreateMap<Purchase, PurchaseResponse>();
            CreateMap<Sale, SaleResponse>();
        }
    }
}
