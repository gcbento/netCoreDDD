using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Domain.Filters;
using JogosAPI.WebAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JogosAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : BaseController
    {
        private readonly IPurchaseAppService _purchaseAppService;

        public PurchaseController(IPurchaseAppService purchaseAppService)
        {
            _purchaseAppService = purchaseAppService;
        }

        [HttpGet]
        [Route("")]
        [ValidateFilterModel]
        public ActionResult Get([FromQuery] PurchaseFilter filter, int pageNumber = 0, int pageSize = 0)
        {
            if (pageNumber > 0 && pageSize > 0)
            {
                var games = _purchaseAppService.GetAll(filter, pageNumber, pageSize);
                return GetResponse(games);
            }
            else
            {
                var game = _purchaseAppService.GetBy(filter);
                return GetResponse(game);
            }
        }

        [HttpPost]
        [ValidateModel]
        public ActionResult Post([FromBody] PurchaseRequest request)
        {
            var result = _purchaseAppService.Add(request);
            return GetResponse(result);
        }

        [HttpPut]
        [ValidateModel]
        public ActionResult Put([FromBody] PurchaseRequest request)
        {
            var result = _purchaseAppService.Update(request);
            return GetResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            var result = _purchaseAppService.Delete(id);
            return GetResponse(result);
        }
    }
}
