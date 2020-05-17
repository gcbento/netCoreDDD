using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using FluentValidation;
using JogosAPI.Domain.Util;
using System;
using System.Linq;

namespace JogosAPI.Domain.Validations
{
    public class AccountValidation : BaseValidation<Account, AccountFilter, IAccountRepository>, IAccountValidation
    {
        private readonly IGameRepository _gameRepository;

        public AccountValidation(IAccountRepository repository, IGameRepository gameRepository) : base(repository)
        {
            _gameRepository = gameRepository;
            ValidatesBase();
            Validate();
        }

        private void Validate()
        {
            try
            {
                var msgObrigatorio = "é obrigatório.";
                var gameId = 0;

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage($"Email {msgObrigatorio}")
                    .Must(email => RegexUtil.IsValidEmail(email)).WithMessage("Email inválido.")
                    .Must((account, email) => EmailAlreadyAdd(account)).WithMessage(a => $"Email '{a.Email}' já cadastrado.");

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage($"Password {msgObrigatorio}")
                    .MinimumLength(5).WithMessage("Quantidade mínima de 5 caracteres no campo Password.");

                RuleFor(x => x.OnlineId)
                    .NotEmpty().WithMessage($"OnlineId {msgObrigatorio}")
                    .Must((account, onlineId) => OnlineIdAlreadyAdd(account)).WithMessage(a => $"OnlineId '{a.OnlineId}' já cadastrado.");

                RuleFor(x => x.BirthDate)
                    .NotEmpty().WithMessage($"BirthDate {msgObrigatorio}");

                RuleFor(x => x.DeactivationDate)
                    .NotEmpty().WithMessage($"Deactivation Date {msgObrigatorio}");

                RuleFor(g => g.Games)
                    .Must((game, name) => GameExists(game, out gameId)).WithMessage(g => $"Game id '{gameId}' não encontrado.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EmailAlreadyAdd(Account account)
        {
            Filter = new AccountFilter();
            Filter.Email = account.Email;

            var objAccount = Repository.GetAll(Filter).FirstOrDefault();

            if (objAccount != null)
                return objAccount.Id == account.Id;

            return objAccount == null;
        }

        public bool OnlineIdAlreadyAdd(Account account)
        {
            Filter = new AccountFilter();
            Filter.OnlineId = account.OnlineId;

            var objAccount = Repository.GetAll(Filter).FirstOrDefault();

            if (objAccount != null)
                return objAccount.Id == account.Id;

            return objAccount == null;
        }

        private bool GameExists(Account account, out int gameId)
        {
            gameId = 0;
            if (account.Games != null && account.Games.Count > 0)
            {
                foreach (var games in account.Games)
                {
                    var game = _gameRepository.GetAll(new GameFilter() { Id = games.GameId }).FirstOrDefault();

                    if (game == null)
                    {
                        gameId = games.GameId;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
