using System;
using System.Net;
using Hahn.ApplicatonProcess.May2020.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.May2020.Infrastructure.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var msg = context.Exception.GetBaseException().Message;

            var statusCode = HttpStatusCode.InternalServerError;
            if (context.Exception is ArgumentException) statusCode = HttpStatusCode.BadRequest;
            if (context.Exception is NotFoundException) statusCode = HttpStatusCode.NotFound;
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(new { error = msg });

            _logger.LogError(context.Exception, msg);

            base.OnException(context);
        }
    }
}