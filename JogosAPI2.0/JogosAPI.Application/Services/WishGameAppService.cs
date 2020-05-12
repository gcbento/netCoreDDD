using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;

namespace JogosAPI.Application.Services
{
    public class WishGameAppService : BaseAppService<WishGame, WishGameRequest, WishGameResponse, WishGameFilter>, IWishGameAppService
    {
        public WishGameAppService(IWishGameRepository repository, IWishGameValidation validation, IMapper mapper) : base(repository, validation, mapper)
        {

        }
    }
}
