using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using JogosAPI.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System;
using JogosAPI.Domain.CommandHandlers;
using JogosAPI.Domain.Util;

namespace JogosAPI.Application.Services
{
    public class GameAppService : BaseAppService<Game, GameRequest, GameResponse, GameFilter>, IGameAppService
    {
        public GameAppService(IGameRepository repository,
                              IGameValidation validation,
                              IMapper mapper,
                              ILoggerRepository logger) : base(repository, validation, mapper, logger)
        { }
    }
}
