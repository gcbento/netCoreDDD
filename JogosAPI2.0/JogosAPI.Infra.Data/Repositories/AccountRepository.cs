using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Infra.Data.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account, AccountFilter, AccountQuery>, IAccountRepository
    {
        public AccountRepository(JogosAPIContext context) : base(context)
        { }

        public override Account GetBy(AccountFilter filter)
        {
            var query = CreateQuery.Where(Query, filter);
            return query.FirstOrDefault();
        }
    }
}
