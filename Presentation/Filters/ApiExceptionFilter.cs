using Application.Common.Exceptions;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var response = context.Exception is ValidationException
                ? ProcessValidationErrors(context)
                : ProcessSystemErrors(context);
            context.Result = new JsonResult(response);
        }

        private static ResponseModel ProcessSystemErrors(ExceptionContext context)
        {
            var message = context.Exception.Message;

            return ResponseModel.Failure(message);



        }

        private ResponseModel ProcessValidationErrors(ExceptionContext context)
        {
            var validationErrors = ((ValidationException)context.Exception).Errors;
            var message = validationErrors.FirstOrDefault().Value.FirstOrDefault();
            return ResponseModel.Failure(message);
        }

    }
}
