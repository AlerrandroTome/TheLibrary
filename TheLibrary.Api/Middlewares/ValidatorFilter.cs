using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace TheLibrary.Api.Middlewares
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(w => w.Value.Errors.Count > 0)
                                              .ToDictionary(w => w.Key, w => w.Value.Errors.Select(w => w.ErrorMessage))
                                              .ToList();

                context.Result = new BadRequestObjectResult(new
                {
                    errors = errors.SelectMany(w => w.Value).ToList()
                });

                return;
            }

            await next();
        }
    }
}
