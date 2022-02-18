using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TheLibrary.Core.DTOs.Response;

namespace TheLibrary.Infrastructure.Middlewares
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult( new Response<string>
            {
                StatusCode = 404,
                AnErrorOcurred = true,
                Data = null,
                ErrorMessage = context.Exception.Message
            });

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
