using System.Linq;

namespace JogosAPI.Domain.Queries
{
    public static class BaseQuery
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int page = 1, int size = 10)
        {
            query = query.Skip((page - 1) * size)
                         .Take(size);

            return query;
        }
    }
}