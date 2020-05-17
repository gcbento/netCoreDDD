using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Validations.Interfaces;
using System.Linq;
using FluentValidation;
using System;

namespace JogosAPI.Domain.Validations
{
    public class SaleValidation : BaseValidation<Sale, SaleFilter, ISaleRepository>, ISaleValidation
    {
        private readonly IGameRepository _gameRepository;

        public SaleValidation(ISaleRepository repository, IGameRepository gameRepository) : base(repository)
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

                RuleFor(x => x.SaleDate)
                    .NotEmpty().WithMessage("PurchaseDate é obrigatório");

                RuleFor(x => x.StartDatePeriod)
                    .NotEmpty().WithMessage("StartDatePeriod é obrigatório");

                RuleFor(x => x.EndDatePeriod)
                    .NotEmpty().WithMessage("EndDatePeriod é obrigatório");

                RuleFor(x => x.GameId)
                    .NotEmpty().WithMessage("GameId é obrigatório")
                    .Must(gameId => GameIdExists(gameId)).WithMessage("GameId não encontrado");
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
