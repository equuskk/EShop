using System;
using System.Collections.Generic;
using System.Net;
using EShop.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShop.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly Dictionary<Type, HttpStatusCode> errors = new Dictionary<Type, HttpStatusCode>
        {
            [typeof(NotFoundException)] = HttpStatusCode.NotFound,
            [typeof(AccessDeniedException)] = HttpStatusCode.Forbidden,
            [typeof(AccessDeniedException)] = HttpStatusCode.BadRequest
        };

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var exception = context.Exception.GetType();
            if(errors.TryGetValue(exception, out var status))
            {
                context.HttpContext.Response.StatusCode = (int) status;
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