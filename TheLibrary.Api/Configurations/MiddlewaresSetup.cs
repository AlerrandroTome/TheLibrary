using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Api.Middlewares;

namespace TheLibrary.Api.Configurations
{
    public static class MiddlewaresSetup
    {
        public static void AddMiddlewareSetup(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options => 
                        options.SuppressModelStateInvalidFilter = true
                    );

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ValidatorFilter>();
            });
        }
    }
}
