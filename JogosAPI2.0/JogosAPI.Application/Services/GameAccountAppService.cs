using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.CommandHandlers;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Util;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Linq;

namespace JogosAPI.Application.Services
{
    public class GameAccountAppService : IGameAccountAppService
    {
        private readonly IGameAccountRepository _repository;
        private IGameAccountValidation _validation;
        private readonly IMapper _mapper;
        private readonly ILoggerRepository _logger;

        public GameAccountAppService(IGameAccountRepository repository,
                              IGameAccountValidation validation,
                              IMapper mapper,
                              ILoggerRepository logger)
        {
            _repository = repository;
            _validation = validation;
            _mapper = mapper;
            _logger = logger;
        }

        public ResponseModel<bool?> DeleteByKey(GameAccountRequest request)
        {
            try
            {
                var entity = _mapper.Map<GameAccount>(request);
                var entityValidate = _validation.Validate(entity);

                if (entityValidate.IsValid)
                {
                    var delete = _repository.DeleteByKey(entity);
                    return ResponseModel<bool?>.GetResponse(delete);
                }
                else
                {
                    var errors = CommandHandler.NotifyValidationErrors(entityValidate.Errors);
                    return ResponseModel<bool?>.GetResponse(errors);
                }
            }
            catch (Exception ex)
            {
                var response = ResponseModel<bool?>.GetErrorResponse();
                CommandHandler.AddLogger(_logger, ex.Message, EnunsAPI.Logtype.Error, request.ToJsonString(), response.ToJsonString());

                return response;
            }
        }
    }
}
