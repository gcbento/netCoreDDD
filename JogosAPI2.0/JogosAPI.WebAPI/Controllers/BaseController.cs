using JogosAPI.Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace JogosAPI.WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public ActionResult GetResponse<T>(ResponseModel<T> result)
        {
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}