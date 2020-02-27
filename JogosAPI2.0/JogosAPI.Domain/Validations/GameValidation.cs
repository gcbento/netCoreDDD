using FluentValidation;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;

namespace JogosAPI.Domain.Validations
{
    public class GameValidation : BaseValidation<Game, GameFilter>, IGameValidation
    {
        public GameValidation(IGameRepository repository) : base(repository)
        {
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Nome do jogo é obrigatório.")
                .MinimumLength(3).WithMessage("Nome do jogo deve ter no mínimo 3 caracteres.")
                .Must(name => GameExists(name)).WithMessage(g => $"Jogo {g.Name} já está cadastrado");
        }

        private bool GameExists(string name)
        {
            var filter = new GameFilter()
            {
                Name = name
            };

            var game = Repository.GetBy(filter);

            return game == null;
        }
    }
}
