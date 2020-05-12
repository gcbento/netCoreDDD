using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System.Collections.Generic;
using System.Linq;

namespace JogosAPI.Domain.Interfaces
{
    public interface IGameAccountRepository : IBaseRepository<GameAccount, GameAccountFilter>
    {
        IQueryable<GameAccount> GetByGameId(int gameId);
        bool DeleteByKey(int gameId, int accountId);
        bool DeleteByGameId(int id);
    }
}
