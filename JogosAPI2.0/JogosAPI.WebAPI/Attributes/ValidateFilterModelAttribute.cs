using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace JogosAPI.WebAPI.Attributes
{
    public class ValidateFilterModelAttribute : ActionFilterAttribute
    {
        private ObjectResult _result;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var queryStringParams = context.HttpContext.Request.Query;

            if (queryStringParams.Count <= 0)
                context.Result = GetResult();
            else
            {
                if ((queryStringParams.ContainsKey("pageNumber") && !queryStringParams.ContainsKey("pageSize")) || 
                    (queryStringParams.ContainsKey("pageSize") && !queryStringParams.ContainsKey("pageNumber")))

                    context.Result = GetResult();
            }
        }

        private ObjectResult GetResult()
        {
            var response = new ResponseModel<object>();

            _result = new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };

            return _result;
        }
    }
}
