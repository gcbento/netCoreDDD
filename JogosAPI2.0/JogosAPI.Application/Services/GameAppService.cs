using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using JogosAPI.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System;
using JogosAPI.Domain.CommandHandlers;
using JogosAPI.Domain.Util;

namespace JogosAPI.Application.Services
{
    public class GameAppService : BaseAppService<Game, GameRequest, GameResponse, GameFilter>, IGameAppService
    {
        private readonly IGameAccountRepository _gameAccountRepository;

        public GameAppService(IGameRepository repository,
                              IGameValidation validation,
                              IMapper mapper,
                              ILoggerRepository logger,
                              IGameAccountRepository gameAccountRepository) : base(repository, validation, mapper, logger)
        {
            _gameAccountRepository = gameAccountRepository;
        }

        public override ResponseModel<GameResponse> GetBy(GameFilter filter)
        {
            try
            {
                GameResponse gameResponse = null;

                var objGame = Repository.GetAll(filter).FirstOrDefault();
                gameResponse = Mapper.Map<GameResponse>(objGame);

                if (objGame?.Accounts != null && objGame.Accounts.Count > 0)
                {
                    foreach (var gameAccount in objGame.Accounts)
                    {
                        var accountResponse = Mapper.Map<AccountResponse>(gameAccount.Account);
                        gameResponse.Accounts.Add(accountResponse);
                    }
                }

                var result = ResponseModel<GameResponse>.GetResponse(gameResponse);

                return result;
            }
            catch (Exception ex)
            {
                var response = ResponseModel<GameResponse>.GetErrorResponse();
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, filter.ToJsonString(), response.ToJsonString());

                return response;
            }
        }

        public override ResponseModel<PagedResponse<GameResponse>> GetAll(GameFilter filter, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var pagedResponse = new PagedResponse<GameResponse>();
                var listGamesResponse = new List<GameResponse>();

                var allGames = Repository.GetAll(filter, true);

                if (allGames != null && allGames.Count() > 0)
                {
                    pagedResponse.Total = allGames.Count();
                    pagedResponse.CurrentPage = pageNumber;

                    var listGames = allGames.Pagination(pageNumber, pageSize)
                                            .ToList();

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

                    pagedResponse.TotalPage = listGamesResponse.Count;
                    pagedResponse.ListData = listGamesResponse;
                }

                var result = ResponseModel<PagedResponse<GameResponse>>.GetResponse(pagedResponse);
                return result;
            }
            catch (Exception ex)
            {
                var response = ResponseModel<PagedResponse<GameResponse>>.GetErrorResponse();
                var request = $"filtro: {filter.ToJsonString()} | pageNumber: {pageNumber} | pageSize: {pageSize}";
                CommandHandler.AddLogger(Logger, ex.Message, EnunsAPI.Logtype.Error, request, response.ToJsonString());

                return response;
            }
        }
    }
}
