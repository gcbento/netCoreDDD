using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Linq;

namespace JogosAPI.Domain.Queries
{
    public static class BaseQuery
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, BaseFilter filter) where T : BaseEntity
        {
            if (filter != null && filter.Id > 0)
                query = query.Where(x => x.Id == filter.Id);

            return query;
        }

        public static IQueryable<T> Select<T>(this IQueryable<T> query) where T : BaseEntity
        {
            return query;
        }

        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int page = 1, int size = 10) where T : BaseEntity
        {
            query = query.Skip((page - 1) * size)
                         .Take(size);

            return query;
        }
    }
}