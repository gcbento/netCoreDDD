using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using FluentValidation;
using System.Reflection;
using JogosAPI.Domain.Util;
using System.Collections.Generic;

namespace JogosAPI.Domain.Validations
{
    public class AccountValidation : BaseValidation<Account, AccountFilter>, IAccountValidation
    {
        private readonly IAccountRepository _repository;
        private readonly IGameRepository _gameRepository;

        public AccountValidation(IAccountRepository repository, IGameRepository gameRepository) : base(repository)
        {
            _repository = repository;
            _gameRepository = gameRepository;
            ValidaCampos();
        }

        private void ValidaCampos()
        {
            var msgObrigatorio = "é obrigatório.";
            var gameId = 0;
            var emailAccount = "";

            RuleFor(x => x.Id)
                .Must((account, id) => AccountExists(id)).WithMessage(g => "Conta informada não encontrada.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage($"Email {msgObrigatorio}")
                .Must(email => RegexUtil.IsValidEmail(email)).WithMessage("Email inválido.")
                .Must((account, email) => AccountExists(account.Id, email)).WithMessage(g => "Email já cadastrado.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage($"Password {msgObrigatorio}")
                .MinimumLength(5).WithMessage("Quantidade mínima de 5 caracteres no campo Password.");

            RuleFor(x => x.OnlineId)
                .NotEmpty().WithMessage($"OnlineId {msgObrigatorio}")
                .Must((account, onlineId) => AccountExists(account.Id, "", onlineId)).WithMessage(g => "OnlineId já cadastrado.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage($"BirthDate {msgObrigatorio}");

            RuleFor(x => x.DeactivationDate)
                .NotEmpty().WithMessage($"Deactivation Date {msgObrigatorio}");

            //RuleFor(x => x.Games)
            //    .Must((games) => GameExists(games, out gameId)).WithMessage((x) => $"Jogo {gameId} não foi encontrado");
                //.Must((account, games) => GameAlreadyAdd(account, games, ref gameId, out emailAccount)).WithMessage((x) => $"Jogo {gameId} já incluído na conta {emailAccount}");
        }

        private bool AccountExists(int id, string email = "", string onlineId = "")
        {
            var filter = new AccountFilter()
            {
                Id = id,
                Email = email,
                OnlineId = onlineId
            };

            var objAccount = _repository.GetBy(filter);
            var res = objAccount != null;

            if (id > 0 && !string.IsNullOrEmpty(email))
            {
                if (objAccount == null)
                {
                    objAccount = _repository.GetBy(new AccountFilter() { Email = email });
                    res = objAccount == null;
                }
            }

            else if (id > 0 && !string.IsNullOrEmpty(onlineId))
            {
                if (objAccount == null)
                {
                    objAccount = _repository.GetBy(new AccountFilter() { OnlineId = onlineId });
                    res = objAccount == null;
                }
            }

            return res;
        }

        private bool GameExists(ICollection<Game> games, out int gameId)
        {
            var res = true;
            var filter = new GameFilter() { };

            if (games != null && games.Count > 0)
            {
                foreach (var g in games)
                {
                    filter.Id = g.Id;
                    var objGame = _gameRepository.GetBy(filter);

                    res = objGame != null;

                    if (!res)
                    {
                        gameId = g.Id;
                        return false;
                    }
                }

            }

            gameId = 0;
            return res;
        }

        private bool GameAlreadyAdd(Account account, ICollection<Game> games, ref int gameId, out string emailAccount)
        {
            emailAccount = "";
            if (gameId <= 0)
            {
                foreach (var game in games)
                {
                    var gameAccount = _repository.GetBy(new AccountFilter() { GameId = game.Id });

                    if (gameAccount != null && gameAccount.Id != account.Id)
                    {
                        gameId = game.Id;
                        emailAccount = gameAccount.Email;
                        return false;
                    }

                    else
                        return true;
                }
            }

            return true;
        }
    }
}
