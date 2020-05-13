using System;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<GameAccount> GetByGameId(int gameId)
        {
            try
            {
                var query = Query.Where(x => x.GameId == gameId);
                query.ForEachAsync(x =>
                {
                    x.Account = _accountRepository.GetAll(new AccountFilter() { Id = x.Id }).FirstOrDefault();
                });

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public bool DeleteByKey(int gameId, int accountId)
        {
            try
            {
                var gameAccount = Query.FirstOrDefault(x => x.AccountId == accountId && x.GameId == gameId);

                if (gameAccount != null)
                {
                    DbSet.Remove(gameAccount);
                    return SaveChanges() > 0;
                }

                return false;
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
