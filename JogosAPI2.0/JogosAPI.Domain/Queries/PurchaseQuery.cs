using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Linq;

namespace JogosAPI.Domain.Queries
{
    public static class PurchaseQuery
    {
        public static IQueryable<Purchase> Where(this IQueryable<Purchase> query, PurchaseFilter filter, bool contains = false)
        {
            if (filter != null)
            {
                if (filter.Id > 0)
                    query = query.Where(x => x.Id == filter.Id);
            }

            return query;
        }

        public static IQueryable<Purchase> Select(this IQueryable<Purchase> query)
        {
            query = query.Select(p => new Purchase()
            {
                Id = p.Id,
                Value = p.Value,
                PurchaseDate = p.PurchaseDate,
                Game = p.Game
            });

            return query;
        }
    }
}
