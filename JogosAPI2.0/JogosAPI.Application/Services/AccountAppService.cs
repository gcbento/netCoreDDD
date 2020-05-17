using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.CommandHandlers;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using JogosAPI.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System;
using JogosAPI.Domain.Util;

namespace JogosAPI.Application.Services
{
    public class AccountAppService : BaseAppService<Account, AccountRequest, AccountResponse, AccountFilter>, IAccountAppService
    {
        private readonly IGameAccountAppService _gameAccountAppService;

        public AccountAppService(IAccountRepository repository,
                                 IAccountValidation validation,
                                 IMapper mapper,
                                 ILoggerRepository logger,
                                 IGameAccountAppService gameAccountAppService) : base(repository, validation, mapper, logger)
        {
            _gameAccountAppService = gameAccountAppService;
        }

        public ResponseModel<bool?> RemoveGame(GameAccountRequest request)
        {
            try
            {
                return _gameAccountAppService.DeleteByKey(request);
            }
            catch (Exception ex)
            {
                var response = ResponseModel<bool?>.GetErrorResponse();
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, request.ToJsonString(), response.ToJsonString());

                return response;
            }
        }
    }
}
