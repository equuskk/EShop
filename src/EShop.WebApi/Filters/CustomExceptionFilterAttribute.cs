using System;
using System.Net;
using System.Security.Authentication;
using EShop.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShop.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            if(context.Exception is NotFoundException || context.Exception is AuthenticationException ||
               context.Exception is AccessDeniedException)
            {
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
                context.Result = new JsonResult(new
                {
                    errors = new[] { context.Exception.Message }
                });
                return;
            }

            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new
            {
                errors = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}