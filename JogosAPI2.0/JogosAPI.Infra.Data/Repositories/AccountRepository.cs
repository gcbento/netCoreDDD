using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JogosAPI.Infra.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account, AccountFilter>, IAccountRepository
    {
        private DbSet<GameAccount> _gameAccountDset;

        public AccountRepository(JogosAPIContext context) : base(context)
        {
            _gameAccountDset = context.GameAccounts;
        }

        public override bool Update(Account entity)
        {
            try
            {
                if (entity.Games != null && entity.Games.Count > 0)
                {
                    foreach (var game in entity.Games)
                    {
                        var gameAccount = _gameAccountDset.Where(x => x.GameId == game.GameId && x.AccountId == entity.Id).FirstOrDefault();
                        if (gameAccount != null)
                            _gameAccountDset.Remove(gameAccount);
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
