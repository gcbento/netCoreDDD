using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Services
{
    public class WishGameAppService : BaseAppService<WishGame, WishGameModel, WishGameFilter>, IWishGameAppService
    {
        public WishGameAppService(IWishGameRepository repository, IWishGameValidation validation, IMapper mapper) : base(repository, validation, mapper)
        {

        }
    }
}
