using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game, GameFilter>
    {
        //List<Game> GetByAccountId(int accountId);

        //void RemoveAccount(Game game);
    }
}
