using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;

namespace JogosAPI.Application.Services
{
    public class AccountAppService : BaseAppService<Account, AccountModel, AccountFilter>, IAccountAppService
    {
        public AccountAppService(IAccountRepository repository, IAccountValidation validation, IMapper mapper) : base(repository, validation, mapper)
        {

        }
    }
}
