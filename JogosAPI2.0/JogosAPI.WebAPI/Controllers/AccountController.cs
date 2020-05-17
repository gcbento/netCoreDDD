using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Application.Models.Request;
using JogosAPI.Domain.Filters;
using JogosAPI.WebAPI.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace JogosAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountAppService _service;

        public AccountController(IAccountAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [ValidateModel]
        public ActionResult Post([FromBody] AccountRequest request)
        {
            var result = _service.Add(request);
            return GetResponse(result);
        }

        [HttpGet]
        [ValidateFilterModel]
        public ActionResult Get([FromQuery] AccountFilter filter, int pageNumber = 0, int pageSize = 0)
        {
            if (pageNumber > 0 && pageSize > 0)
            {
                var result = _service.GetAll(filter, pageNumber, pageSize);
                return GetResponse(result);
            }
            else
            {
                var result = _service.GetBy(filter);
                return GetResponse(result);
            }
        }

        [HttpPut]
        [ValidateModel]
        public ActionResult Put([FromBody] AccountRequest request)
        {
            var result = _service.Update(request);
            return GetResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return GetResponse(result);
        }

        [HttpDelete]
        [Route("RemoveGame")]
        public ActionResult RemoveGame([FromQuery] GameAccountRequest request)
        {
            var result = _service.RemoveGame(request);
            return GetResponse(result);
        }
    }
}
