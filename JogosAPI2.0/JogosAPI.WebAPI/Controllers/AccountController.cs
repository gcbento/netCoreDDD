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
        public ActionResult Get([FromQuery] AccountFilter filter)
        {
            var list = _service.GetAll(filter);
            return GetResponse(list);
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
            var deleted = _service.Delete(id);
            return GetResponse(deleted);
        }
    }
}
