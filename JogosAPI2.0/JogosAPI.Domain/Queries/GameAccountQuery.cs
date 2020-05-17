using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Linq;

namespace JogosAPI.Domain.Queries
{
    public static class GameAccountQuery
    {
        public static IQueryable<GameAccount> Where(this IQueryable<GameAccount> query, GameAccountFilter filter, bool contains = false)
        {
            if (filter != null)
            {
                if (filter.AccountId > 0)
                    query = query.Where(x => x.AccountId == filter.AccountId);

                if (filter.GameId > 0)
                    query = query.Where(x => x.GameId == filter.GameId);
            }

            return query;
        }
    }
}
