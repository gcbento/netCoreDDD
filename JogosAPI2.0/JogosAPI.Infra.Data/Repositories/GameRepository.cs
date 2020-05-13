using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Queries;
using JogosAPI.Infra.Data.Context;
using System.Linq;
using System;

namespace JogosAPI.Infra.Data.Repositories
{
    public class GameRepository : BaseRepository<Game, GameFilter>, IGameRepository
    {
        private readonly IGameAccountRepository _gameAccountRepository;

        public GameRepository(JogosAPIContext context, IGameAccountRepository gameAccountRepository) : base(context)
        {
            _gameAccountRepository = gameAccountRepository;
        }

        public override bool Update(Game entity)
        {
            try
            {
                if (entity.Accounts != null && entity.Accounts.Count > 0)
                    foreach (var account in entity.Accounts)
                        _gameAccountRepository.DeleteByKey(entity.Id, account.AccountId);

                return base.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public override IQueryable<Game> GetAll(GameFilter filter, bool contains = false)
        {
            try
            {
                var query = Query.Where(filter, contains)
                                 .Select();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }
    }
}
