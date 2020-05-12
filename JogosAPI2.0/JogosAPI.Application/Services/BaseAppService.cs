using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.CommandHandlers;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
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
        where TFilter : BaseFilter
    {
        public readonly IBaseRepository<TEntity, TFilter> Repository;
        public readonly IMapper Mapper;

        public IBaseValidation<TEntity> Validate { get; }

        public BaseAppService(IBaseRepository<TEntity, TFilter> repository, IBaseValidation<TEntity> validation, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
            Validate = validation;
        }

        public virtual ResponseModel<bool> Add(TRequest model)
        {
            var entity = Mapper.Map<TEntity>(model);
            var entityValidate = Validate.Validate(entity);

            if (entityValidate.IsValid)
            {
                model = Mapper.Map<TRequest>(Repository.Add(entity));
                var added = model.Id > 0;
                return ResponseModel<bool>.GetResponse(added);
            }
            else
            {
                var errors = CommandHandler.NotifyValidationErrors(entityValidate.Errors);
                return ResponseModel<bool>.GetResponse(errors);
            }
        }

        public ResponseModel<bool> Delete(int id)
        {
            var delete = Repository.Delete(id);
            return ResponseModel<bool>.GetResponse(delete);
        }

        public virtual ResponseModel<List<TResponse>> GetAll(TFilter filter)
        {
            var list = Mapper.Map<List<TResponse>>(Repository.GetAll(filter).ToList());
            var resultList = ResponseModel<List<TResponse>>.GetResponse(list);

            return resultList;
        }

        public virtual ResponseModel<TResponse> GetBy(TFilter filter)
        {
            var obj = Mapper.Map<TResponse>(Repository.GetBy(filter));
            var result = ResponseModel<TResponse>.GetResponse(obj);

            return result;
        }

        public virtual ResponseModel<bool> Update(TRequest model)
        {
            var entity = Mapper.Map<TEntity>(model);
            var entityValidate = Validate.Validate(entity);

            if (entityValidate.IsValid)
            {
                var updated = Repository.Update(entity);
                return ResponseModel<bool>.GetResponse(updated);
            }
            else
            {
                var errors = CommandHandler.NotifyValidationErrors(entityValidate.Errors);
                return ResponseModel<bool>.GetResponse(errors);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
