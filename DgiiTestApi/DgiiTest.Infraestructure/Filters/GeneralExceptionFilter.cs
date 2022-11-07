using DgiiTest.Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DgiiTest.Infraestructure.Filters
{
    public class GeneralExceptionFilter: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(ExceptionResponse))
            {
                var exception = (ExceptionResponse)context.Exception;
                var validation = new
                {
                    Status = 500,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new { error = new[] { validation } };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
