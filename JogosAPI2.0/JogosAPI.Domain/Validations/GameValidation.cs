using FluentValidation;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System.Linq;

namespace JogosAPI.Domain.Validations
{
    public class GameValidation : BaseValidation<Game, GameFilter>, IGameValidation
    {
        private readonly IAccountRepository _accountRepository;

        public GameValidation(IGameRepository repository, IAccountRepository accountRepository) : base(repository)
        {
            _accountRepository = accountRepository;
            Validate();
        }

        private void Validate()
        {
            var accountId = 0;
            RuleFor(g => g.Id)
                .Must((game, id) => GameIdExists(game)).WithMessage(g => $"Jogo id '{g.Id}' não encontrado");

            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Nome do jogo é obrigatório.")
                .MinimumLength(3).WithMessage("Nome do jogo deve ter no mínimo 3 caracteres.")
                .Must((game, name) => CheckGameAlreadyAdd(game)).WithMessage(g => $"Jogo '{g.Name}' já está cadastrado");

            RuleFor(g => g.Accounts)
                .Must((game, name) => AccountExists(game, out accountId)).WithMessage(g => $"Conta id '{accountId}' não encontrada.");
        }

        private bool GameIdExists(Game game)
        {
            if (game.Id > 0)
            {
                var objGame = Repository.GetBy(game.Id);
                return objGame != null;
            }

            return true;
        }

        private bool CheckGameAlreadyAdd(Game game)
        {
            Filter.Name = game.Name;
            var objGame = Repository.GetBy(Filter);

            if (objGame != null)
                return game.Id == objGame.Id;

            return objGame == null;
        }

        private bool AccountExists(Game game, out int accountId)
        {
            accountId = 0;
            if (game.Accounts != null && game.Accounts.Count > 0)
            {
                foreach (var accountsId in game.Accounts)
                {
                    var account = _accountRepository.GetBy(accountsId.AccountId);

                    if (account == null)
                    {
                        accountId = accountsId.AccountId;
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckAccountAlreadyAdd(Game game, out int accountId)
        {
            accountId = 0;
            if (game.Accounts != null && game.Accounts.Count > 0)
            {
                foreach (var accountsId in game.Accounts)
                {
                    Filter = new GameFilter();
                    Filter.AccountId = accountsId.AccountId;
                    var gamesByAccountId = Repository.GetAll(Filter).ToList();

                    if (gamesByAccountId.Count > 0)
                    {
                        accountId = accountsId.AccountId;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
