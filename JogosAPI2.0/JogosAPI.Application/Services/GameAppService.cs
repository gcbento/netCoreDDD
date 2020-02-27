using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Services
{
    public class GameAppService : BaseAppService<Game, GameModel, GameFilter>, IGameAppService
    {
        public GameAppService(IGameRepository repository, IGameValidation validation, IMapper mapper) : base(repository, validation,  mapper)
        {
        }
    }
}
