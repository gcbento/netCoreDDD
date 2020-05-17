using FluentValidation;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace JogosAPI.Domain.Validations
{
    public class GameAccountValidation : BaseValidation<GameAccount, GameAccountFilter, IGameAccountRepository>, IGameAccountValidation
    {
        public GameAccountValidation(IGameAccountRepository repository) : base(repository)
        {
            Validate();
        }

        private void Validate()
        {
            try
            {
                var gameExists = false;

                RuleFor(g => g.GameId)
                    .NotEmpty().WithMessage("Informe um gameId")
                    .Must((gameAccount, gameId) => GameIdExists(gameAccount, out gameExists)).WithMessage("Jogo não encontrado ou não está associado a nenhuma conta");

                RuleFor(g => g.AccountId)
                    .NotEmpty().WithMessage("Informe um accountId")
                    .Must((gameAccount, gameId) => AccountIdExists(gameAccount, gameExists)).WithMessage("Conta não encontrada ou não está associada para esse jogo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool GameIdExists(GameAccount gameAccount, out bool gameExists)
        {
            Filter = new GameAccountFilter();
            Filter.GameId = gameAccount.GameId;
            var objGameAccount = Repository.GetBy(Filter).ToList();

            gameExists = objGameAccount?.Count > 0;

            return gameExists;
        }

        private bool AccountIdExists(GameAccount gameAccount, bool gameExists)
        {
            if (gameExists)
            {
                Filter.AccountId = gameAccount.AccountId;
                Filter.GameId = gameAccount.GameId;
                var objGameAccount = Repository.GetBy(Filter).FirstOrDefault();

                return objGameAccount != null;
            }

            return false;
        }
    }
}
