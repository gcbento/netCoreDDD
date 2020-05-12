using FluentValidation;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Validations
{
    public class BaseValidation<TEntity, TFilter> : AbstractValidator<TEntity>, IBaseValidation<TEntity>
        where TEntity : BaseEntity
        where TFilter : BaseFilter, new()
    {
        public readonly IBaseRepository<TEntity, TFilter> Repository;
        protected TFilter Filter;

        public BaseValidation(IBaseRepository<TEntity, TFilter> repository)
        {
            Repository = repository;
            Filter = new TFilter();
        }
    }
}
