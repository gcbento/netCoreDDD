using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Linq;

namespace JogosAPI.Domain.Queries
{
    public static class AccountQuery
    {
        public static IQueryable<Account> Where(this IQueryable<Account> query, AccountFilter filter, bool contais = false)
        {
            if (filter != null)
            {
                if (filter.Id > 0)
                    query = query.Where(x => x.Id == filter.Id);

                if (!string.IsNullOrEmpty(filter.Email))
                    query = query.Where(x => x.Email == filter.Email);

                if (!string.IsNullOrEmpty(filter.OnlineId))
                    query = query.Where(x => x.OnlineId == filter.OnlineId);

                //if (filter.GameId > 0)
                //    query = query.Where(x => x.Games.Any(y => y.Id == filter.GameId));
            }

            return query;
        }

        public static IQueryable<Account> Select(this IQueryable<Account> query)
        {
            query = query.Select(a => new Account()
            {
                Id = a.Id,
                Email = a.Email,
                Password = a.Password,
                OnlineId = a.OnlineId,
                BirthDate = a.BirthDate,
                DeactivationDate = a.DeactivationDate,
                Games = a.Games.Select(a => new GameAccount()
                {
                    Game = a.Game
                }).ToList()
            });

            return query;
        }
    }
}
