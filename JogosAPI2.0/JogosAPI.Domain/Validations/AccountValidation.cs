using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Validations
{
    public class AccountValidation : BaseValidation<Account, AccountFilter>, IAccountValidation
    {
        public AccountValidation(IAccountRepository repository) : base(repository)
        {

        }
    }
}
