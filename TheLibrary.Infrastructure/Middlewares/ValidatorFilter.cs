using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Response;

namespace TheLibrary.Infrastructure.Middlewares
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(w => w.Value.Errors.Count > 0)
                                              .Select(w => w.Value.Errors.Select(w => w.ErrorMessage))
                                              .ToList();

                context.Result = new BadRequestObjectResult(new Response<string>
                {
                    StatusCode = 404,
                    AnErrorOcurred = true,
                    Data = null,
                    ErrorMessage = string.Concat(errors)
                });

                return;
            }

            await next();
        }
    }
}
