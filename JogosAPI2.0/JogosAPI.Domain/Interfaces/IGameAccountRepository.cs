using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Collections.Generic;
using System.Linq;

namespace JogosAPI.Domain.Interfaces
{
    public interface IGameAccountRepository : IBaseRepository<GameAccount, GameAccountFilter>
    {
        IQueryable<GameAccount> GetBy(GameAccountFilter filter);
        bool DeleteByKey(GameAccount entity);
        bool DeleteByGameId(int id);
    }
}
