using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class WishGameRepository : BaseRepository<WishGame, WishGameFilter>, IWishGameRepository
    {
        public WishGameRepository(JogosAPIContext context) : base(context)
        { }
    }
}
