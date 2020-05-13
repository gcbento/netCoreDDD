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
using System.Collections.Generic;
using System.Linq;

namespace JogosAPI.Application.Services
{
    public class BaseAppService<TEntity, TRequest, TResponse, TFilter> : IBaseAppService<TRequest, TResponse, TFilter>
        where TEntity : BaseEntity
        where TRequest : BaseRequest
        where TResponse : BaseResponse
        where TFilter : BaseFilter, new()
    {
        public readonly IBaseRepository<TEntity, TFilter> Repository;
        public readonly IMapper Mapper;
        public readonly ILoggerRepository Logger;

        public IBaseValidation<TEntity> Validate { get; }

        public BaseAppService(IBaseRepository<TEntity, TFilter> repository, IBaseValidation<TEntity> validation, IMapper mapper, ILoggerRepository loggerRepository)
        {
            Repository = repository;
            Mapper = mapper;
            Validate = validation;
            Logger = loggerRepository;
        }

        public virtual ResponseModel<bool?> Add(TRequest request)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(request);
                var entityValidate = Validate.Validate(entity);

                if (entityValidate.IsValid)
                {
                    var objResponse = Mapper.Map<TResponse>(Repository.Add(entity));
                    var added = objResponse.Id > 0;
                    return ResponseModel<bool?>.GetResponse(added);
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
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, request.ToJsonString(), response.ToJsonString());

                return response;
            }
        }

        public ResponseModel<bool?> Delete(int id)
        {
            try
            {
                var entity = Repository.GetAll(new TFilter() { Id = id }).FirstOrDefault();

                if (entity != null)
                {
                    var delete = Repository.Delete(id);
                    return ResponseModel<bool?>.GetResponse(delete);
                }
                else
                {
                    var errors = CommandHandler.NotifyValidationErrors("Id não encontrado para exclusão");
                    return ResponseModel<bool?>.GetResponse(errors);
                }
            }
            catch (Exception ex)
            {
                var response = ResponseModel<bool?>.GetErrorResponse();
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, $"id = {id.ToString()}", response.ToJsonString());

                return response;
            }
        }

        public virtual ResponseModel<PagedResponse<TResponse>> GetAll(TFilter filter, int pageNumber = 0, int pageSize = 10)
        {
            try
            {
                var list = Mapper.Map<List<TResponse>>(Repository.GetAll(filter).ToList());
                var pagedResponse = new PagedResponse<TResponse>() { ListData = list };
                var resultList = ResponseModel<PagedResponse<TResponse>>.GetResponse(pagedResponse);

                return resultList;
            }
            catch (Exception ex)
            {
                var response = ResponseModel<PagedResponse<TResponse>>.GetErrorResponse();
                var request = $"filtro: {filter.ToJsonString()} | pageNumber: {pageNumber} | pageSize: {pageSize}";
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, request, response.ToJsonString());

                return response;
            }
        }

        public virtual ResponseModel<TResponse> GetBy(TFilter filter)
        {
            try
            {
                var obj = Mapper.Map<TResponse>(Repository.GetAll(filter).FirstOrDefault());
                var result = ResponseModel<TResponse>.GetResponse(obj);

                return result;
            }
            catch (Exception ex)
            {
                var response = ResponseModel<TResponse>.GetErrorResponse();
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, filter.ToJsonString(), response.ToJsonString());

                return response;
            }
        }

        public virtual ResponseModel<bool?> Update(TRequest request)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(request);
                var entityValidate = Validate.Validate(entity);

                if (entityValidate.IsValid)
                {
                    var updated = Repository.Update(entity);
                    return ResponseModel<bool?>.GetResponse(updated);
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
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, request.ToJsonString(), response.ToJsonString());

                return response;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
