using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Linq;

namespace JogosAPI.Domain.Queries
{
    public static class SaleQuery
    {
        public static IQueryable<Sale> Where(this IQueryable<Sale> query, SaleFilter filter, bool contains = false)
        {
            if (filter != null)
            {
                if (filter.Id > 0)
                    query = query.Where(x => x.Id == filter.Id);
            }

            return query;
        }

        public static IQueryable<Sale> Select(this IQueryable<Sale> query)
        {
            query = query.Select(p => new Sale()
            {
                Id = p.Id,
                Value = p.Value,
                SaleDate = p.SaleDate,
                StartDatePeriod = p.StartDatePeriod,
                EndDatePeriod = p.EndDatePeriod,
                Game = p.Game
            });

            return query;
        }
    }
}
