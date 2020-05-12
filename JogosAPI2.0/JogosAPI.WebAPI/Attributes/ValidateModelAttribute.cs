using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace JogosAPI.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private ObjectResult _result;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                var action = context.RouteData.Values["action"];
                var model = (BaseRequest)context.ActionArguments.Values.ToList()[0];
                var errors = new List<string>();

                if (model != null)
                {
                    switch (action.ToString().ToUpper())
                    {
                        case "PUT":
                            if (model != null && model.Id <= 0)
                                errors.Add("Id é obrigatório para alteração");
                            break;

                        case "POST":
                            if (model.Id > 0)
                                errors.Add("Id é somente para alteração");
                            break;
                    }
                }
                else
                    errors.Add("Request inválido");

                if (errors.Count > 0)
                    context.Result = GetResult(errors, (int)HttpStatusCode.BadRequest);
            }
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                context.Result = GetResult(errors.ToList(), (int)HttpStatusCode.BadRequest);
            }
        }

        private ObjectResult GetResult(List<string> errors, int statusCode)
        {
            var msg = errors.ToArray();
            var response = new ResponseModel<object>();

            response.Messages = errors.ToArray();

            _result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            return _result;
        }
    }
}
