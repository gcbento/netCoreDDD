using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account, AccountFilter>
    {
    }
}
