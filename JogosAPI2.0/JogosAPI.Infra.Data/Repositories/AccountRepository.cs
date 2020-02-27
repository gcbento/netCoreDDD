using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account, AccountFilter>, IAccountRepository
    {
        public AccountRepository(JogosAPIContext context) : base(context)
        { }
    }
}
