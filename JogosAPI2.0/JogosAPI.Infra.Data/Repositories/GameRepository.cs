using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class GameRepository : BaseRepository<Game, GameFilter>, IGameRepository
    {
        public GameRepository(JogosAPIContext context) : base(context)
        { }

        public override Game GetBy(GameFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                    return DbSet.AsQueryable().FirstOrDefault(x => x.Name == filter.Name);
                else if (filter.Id > 0)
                    return DbSet.Find(filter.Id);

                return base.GetBy(filter);
            }

            return null;
        }
    }
}
