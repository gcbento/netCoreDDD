using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Infra.Data.Queries
{
    public class GameQuery : BaseQuery<Game, GameFilter>
    {
        public override IQueryable<Game> Where(IQueryable<Game> query, GameFilter filter, bool contains = false)
        {
            if (filter != null)
            {
                if (filter.Id > 0)
                    query = query.Where(x => x.Id == filter.Id);

                if (!string.IsNullOrEmpty(filter.Name) && !contains)
                    query = query.Where(x => x.Name == filter.Name);
                else
                    query = query.Where(x => x.Name.Contains(filter.Name));

                if (filter.AccountId > 0)
                    query = query.Where(x => x.Accounts.Any(y => y.AccountId == filter.AccountId));
            }

            return query;
        }

        public override IQueryable<Game> Select(IQueryable<Game> query)
        {
            query = query.Select(g => new Game()
            {
                Id = g.Id,
                Name = g.Name,
                Completed = g.Completed,
                Accounts = g.Accounts.Select(a => new GameAccount() 
                {
                    Account = a.Account
                }).ToList()
            });

            return query;
        }
    }
}
