using FluentValidation;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Domain.Validations
{
    public class PurchaseValidation : BaseValidation<Purchase, PurchaseFilter, IPurchaseRepository>, IPurchaseValidation
    {
        private readonly IGameRepository _gameRepository;

        public PurchaseValidation(IPurchaseRepository repository, IGameRepository gameRepository) : base(repository)
        {
            _gameRepository = gameRepository;
            ValidatesBase();
            Validate();
        }

        private void Validate()
        {
            try
            {
                RuleFor(x => x.Value)
                    .NotEmpty().WithMessage("Valor é obrigatório");

                RuleFor(x => x.GameId)
                    .NotEmpty().WithMessage("GameId é obrigatório")
                    .Must(gameId => GameIdExists(gameId)).WithMessage("GameId não encontrado");

                RuleFor(x => x.PurchaseDate)
                    .NotEmpty().WithMessage("PurchaseDate é obrigatório");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool GameIdExists(int gameId)
        {
            if (gameId > 0)
            {
                var objGame = _gameRepository.GetAll(new GameFilter() { Id = gameId }).FirstOrDefault();
                return objGame != null;
            }

            return false;
        }
    }
}
