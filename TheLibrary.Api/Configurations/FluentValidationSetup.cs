using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace TheLibrary.Api.Configurations
{
    public static class FluentValidationSetup
    {
        public static void AddFluentValidationSetup(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}
