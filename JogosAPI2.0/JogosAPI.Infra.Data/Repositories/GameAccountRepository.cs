
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Infra.Data.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JogosAPI.Infra.Data.Repositories
{
    public class GameAccountRepository : BaseRepository<GameAccount, GameAccountFilter, GameAccountQuery>, IGameAccountRepository
    {
        private readonly IAccountRepository _accountRepository;

        public GameAccountRepository(JogosAPIContext context, IAccountRepository accountRepository) : base(context)
        {
            _accountRepository = accountRepository;
        }

        public IQueryable<GameAccount> GetByGameId(int gameId)
        {
            var query = Query.Where(x => x.GameId == gameId);
            query.ForEachAsync(x =>
            {
                x.Account = _accountRepository.GetBy(x.Id);
            });

            return query;
        }

        public bool DeleteByKey(int gameId, int accountId)
        {
            DbSet.Remove(Query.FirstOrDefault(x => x.AccountId == accountId && x.GameId == gameId));
            return SaveChanges() > 0;
        }

        public bool DeleteByGameId(int id)
        {
            var games = Query.Where(x => x.GameId == id);
            DbSet.RemoveRange(games);
            return SaveChanges() > 0;
        }
    }
}
