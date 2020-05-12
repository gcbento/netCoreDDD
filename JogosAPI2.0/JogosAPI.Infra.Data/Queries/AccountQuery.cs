using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Linq;

namespace JogosAPI.Infra.Data.Queries
{
    public class AccountQuery : BaseQuery<Account, AccountFilter>
    {
        public override IQueryable<Account> Where(IQueryable<Account> query, AccountFilter filter, bool contais = false)
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
    }
}
