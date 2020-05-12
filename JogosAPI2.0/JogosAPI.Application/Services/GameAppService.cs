using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JogosAPI.Application.Services
{
    public class GameAppService : BaseAppService<Game, GameRequest, GameResponse, GameFilter>, IGameAppService
    {
        private readonly IGameAccountRepository _gameAccountRepository;

        public GameAppService(IGameRepository repository,
                              IGameValidation validation,
                              IMapper mapper,
                              IGameAccountRepository gameAccountRepository) : base(repository, validation, mapper)
        {
            _gameAccountRepository = gameAccountRepository;
        }

        public override ResponseModel<GameResponse> GetBy(GameFilter filter)
        {
            GameResponse gameResponse = null;
            var objGame = Repository.GetBy(filter);

            if (objGame != null && objGame.Accounts != null && objGame.Accounts.Count > 0)
            {
                gameResponse = Mapper.Map<GameResponse>(objGame);
                foreach (var gameAccount in objGame.Accounts)
                {
                    var accountResponse = Mapper.Map<AccountResponse>(gameAccount.Account);
                    gameResponse.Accounts.Add(accountResponse);
                }
            }

            var result = ResponseModel<GameResponse>.GetResponse(gameResponse);

            return result;
        }

        public override ResponseModel<List<GameResponse>> GetAll(GameFilter filter)
        {
            List<GameResponse> listGamesResponse = new List<GameResponse>();
            var listGames = Repository.GetAll(filter).ToList();

            if (listGames != null && listGames.Count > 0)
            {
                foreach (var objGame in listGames)
                {
                    var gameResponse = Mapper.Map<GameResponse>(objGame);

                    if (objGame.Accounts != null && objGame.Accounts.Count > 0)
                    {
                        foreach (var gameAccount in objGame.Accounts)
                        {
                            var accountResponse = Mapper.Map<AccountResponse>(gameAccount.Account);
                            gameResponse.Accounts.Add(accountResponse);
                        }
                    }

                    listGamesResponse.Add(gameResponse);
                }
            }

            var result = ResponseModel<List<GameResponse>>.GetResponse(listGamesResponse);
            return result;
        }
    }
}
