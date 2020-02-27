using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JogosAPI.Application.Models;
using Microsoft.AspNetCore.Http;
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