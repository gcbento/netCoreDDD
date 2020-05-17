using FluentValidation;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Domain.Validations
{
    public class BaseValidation<TEntity, TFilter, TRepository> : AbstractValidator<TEntity>, IBaseValidation<TEntity>
        where TEntity : BaseEntity
        where TFilter : BaseFilter, new()
        where TRepository : IBaseRepository<TEntity, TFilter>
    {
        public readonly TRepository Repository;
        protected TFilter Filter;

        public BaseValidation(TRepository repository)
        {
            Repository = repository;
            Filter = new TFilter();
        }

        public void ValidatesBase()
        {
            RuleFor(x => x.Id)
                   .Must((purchase, id) => EntityIdExists(purchase)).WithMessage("Id não encontrado para alteração");
        }

        private bool EntityIdExists(TEntity entity)
        {
            if (entity.Id > 0)
            {
                Filter.Id = entity.Id;
                var objPurchase = Repository.GetAll(Filter).FirstOrDefault();
                return objPurchase != null;
            }

            return true;
        }
    }
}
