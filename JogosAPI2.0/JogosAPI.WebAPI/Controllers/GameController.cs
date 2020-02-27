using System;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JogosAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : BaseController
    {
        private readonly IGameAppService _gameService;

        public GameController(IGameAppService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get([FromQuery] GameFilter filter)
        {
            var games = _gameService.GetAll(filter);
            return GetResponse(games);
        }

        [HttpPost]
        public ActionResult Post([FromBody] GameModel model)
        {
            var result = _gameService.Add(model);
            return GetResponse(result);
        }

        [HttpPut]
        public ActionResult Put([FromBody] GameModel model)
        {
            var result = _gameService.Update(model);
            return GetResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            var result = _gameService.Delete(id);
            return GetResponse(result);
        }
    }
}
