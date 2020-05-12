using System;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Application.Models.Request;
using JogosAPI.Domain.Filters;
using JogosAPI.WebAPI.Attributes;
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
            var games = _gameService.GetBy(filter);
            return GetResponse(games);
        }

        [HttpGet]
        [Route("getList")]
        public ActionResult GetList([FromQuery] GameFilter filter)
        {
            var games = _gameService.GetAll(filter);
            return GetResponse(games);
        }

        [HttpPost]
        [ValidateModel]
        public ActionResult Post([FromBody] GameRequest request)
        {
            var result = _gameService.Add(request);
            return GetResponse(result);
        }

        [HttpPut]
        [ValidateModel]
        public ActionResult Put([FromBody] GameRequest request)
        {
            var result = _gameService.Update(request);
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
