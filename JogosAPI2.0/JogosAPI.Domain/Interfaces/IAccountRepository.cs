﻿using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;

namespace JogosAPI.Domain.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account, AccountFilter>
    {
    }
}
