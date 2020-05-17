using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Queries;
using JogosAPI.Infra.Data.Context;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace JogosAPI.Infra.Data.Repositories
{
    public class GameRepository : BaseRepository<Game, GameFilter>, IGameRepository
    {
        private DbSet<GameAccount> _gameAccountDbset;

        public GameRepository(JogosAPIContext context) : base(context)
        {
            _gameAccountDbset = context.GameAccounts;
        }

        public override bool Update(Game entity)
        {
            try
            {
                if (entity.Accounts != null && entity.Accounts.Count > 0)
                {
                    foreach (var account in entity.Accounts)
                    {
                        var gameAccount = _gameAccountDbset.Where(x => x.AccountId == account.AccountId && x.GameId == entity.Id).FirstOrDefault();
                        if (gameAccount != null)
                            _gameAccountDbset.Remove(gameAccount);
                    }
                }

                return base.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }
    }
}
