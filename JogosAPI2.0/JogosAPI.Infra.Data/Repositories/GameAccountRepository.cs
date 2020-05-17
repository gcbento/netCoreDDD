using System;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Domain.Queries;
using System.Linq;

namespace JogosAPI.Infra.Data.Repositories
{
    public class GameAccountRepository : BaseRepository<GameAccount, GameAccountFilter>, IGameAccountRepository
    {
        private readonly IAccountRepository _accountRepository;

        public GameAccountRepository(JogosAPIContext context, IAccountRepository accountRepository) : base(context)
        {
            _accountRepository = accountRepository;
        }

        public IQueryable<GameAccount> GetBy(GameAccountFilter filter)
        {
            try
            {
                var query = Query.Where(filter);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public bool DeleteByKey(GameAccount entity)
        {
            try
            {
                DbSet.Remove(entity);
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public bool DeleteByGameId(int id)
        {
            try
            {
                var games = Query.Where(x => x.GameId == id);
                DbSet.RemoveRange(games);
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }
    }
}
