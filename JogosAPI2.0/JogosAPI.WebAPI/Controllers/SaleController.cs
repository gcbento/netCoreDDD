using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Domain.Filters;
using JogosAPI.WebAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JogosAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : BaseController
    {
        private readonly ISaleAppService _saleAppService;

        public SaleController(ISaleAppService saleAppService)
        {
            _saleAppService = saleAppService;
        }

        [HttpGet]
        [Route("")]
        [ValidateFilterModel]
        public ActionResult Get([FromQuery] SaleFilter filter, int pageNumber = 0, int pageSize = 0)
        {
            if (pageNumber > 0 && pageSize > 0)
            {
                var games = _saleAppService.GetAll(filter, pageNumber, pageSize);
                return GetResponse(games);
            }
            else
            {
                var game = _saleAppService.GetBy(filter);
                return GetResponse(game);
            }
        }

        [HttpPost]
        [ValidateModel]
        public ActionResult Post([FromBody] SaleRequest request)
        {
            var result = _saleAppService.Add(request);
            return GetResponse(result);
        }

        [HttpPut]
        [ValidateModel]
        public ActionResult Put([FromBody] SaleRequest request)
        {
            var result = _saleAppService.Update(request);
            return GetResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            var result = _saleAppService.Delete(id);
            return GetResponse(result);
        }
    }
}
