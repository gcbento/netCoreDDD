using AutoMapper;
using AutoMapper.QueryableExtensions;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
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
    public class BaseAppService<TEntity, TModel, TFilter> : IBaseAppService<TModel, TFilter>
        where TModel : BaseModel
        where TEntity : BaseEntity
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

        public ResponseModel<TModel> Add(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            var entityValidate = Validate.Validate(entity);

            if (entityValidate.IsValid)
            {
                model = Mapper.Map<TModel>(Repository.Add(entity));
                return ResponseModel<TModel>.GetResponse(model);
            }
            else
            {
                var errors = CommandHandler.NotifyValidationErrors(entityValidate.Errors);
                return ResponseModel<TModel>.GetResponse(errors);
            }
        }

        public ResponseModel<bool> Delete(int id)
        {
            var delete = Repository.Delete(id);
            return ResponseModel<bool>.GetResponse(delete);
        }

        public virtual ResponseModel<List<TModel>> GetAll(TFilter filter)
        {
            var list = Mapper.Map<List<TModel>>(Repository.GetAll(filter).ToList());
            var resultList = ResponseModel<List<TModel>>.GetResponse(list);
            return resultList;
        }

        public virtual ResponseModel<TModel> GetBy(TFilter filter)
        {
            var obj = Mapper.Map<TModel>(Repository.GetBy(filter));
            var result = ResponseModel<TModel>.GetResponse(obj);
            return result;
        }

        public ResponseModel<bool> Update(TModel model)
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
