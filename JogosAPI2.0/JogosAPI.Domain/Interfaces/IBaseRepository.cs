using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, TFilter> 
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        TEntity Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int id);

        TEntity GetBy(int id);

        TEntity GetBy(TFilter filter);

        IQueryable<TEntity> GetAll(TFilter filter);

        int SaveChanges();
    }
}
