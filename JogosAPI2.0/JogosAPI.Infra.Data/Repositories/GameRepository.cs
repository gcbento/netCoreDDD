using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Infra.Data.Queries;
using System.Linq;

namespace JogosAPI.Infra.Data.Repositories
{
    public class GameRepository : BaseRepository<Game, GameFilter, GameQuery>, IGameRepository
    {
        private readonly IGameAccountRepository _gameAccountRepository;

        public GameRepository(JogosAPIContext context, IGameAccountRepository gameAccountRepository) : base(context)
        {
            _gameAccountRepository = gameAccountRepository;
        }

        public override bool Update(Game entity)
        {
            if (entity.Accounts != null && entity.Accounts.Count > 0)
                foreach (var account in entity.Accounts)
                    _gameAccountRepository.DeleteByKey(entity.Id, account.AccountId);

            return base.Update(entity);
        }

        public override Game GetBy(GameFilter filter)
        {
            var query = CreateQuery.Where(Query, filter);
            query = CreateQuery.Select(query);
            return query.FirstOrDefault();
        }

        public override IQueryable<Game> GetAll(GameFilter filter)
        {
            var query = CreateQuery.Where(Query, filter, true);
            query = CreateQuery.Select(query);
            return query;
        }
    }
}
