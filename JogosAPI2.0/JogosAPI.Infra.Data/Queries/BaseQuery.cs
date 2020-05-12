using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Infra.Data.Queries
{
    public class BaseQuery<TEntity, TFilter>
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        public virtual IQueryable<TEntity> Where(IQueryable<TEntity> query, TFilter filter, bool contains = false)
        {
            if (filter != null)
            {
                if (filter.Id > 0)
                    query = query.Where(x => x.Id == filter.Id);
            }

            return query;
        }

        public virtual IQueryable<TEntity> Select(IQueryable<TEntity> query)
        {
            return query;
        }
    }
}