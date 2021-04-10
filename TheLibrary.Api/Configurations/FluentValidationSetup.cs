using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace TheLibrary.Api.Configurations
{
    public static class FluentValidationSetup
    {
        public static void AddFluentValidationSetup(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
                options.ValidatorOptions.LanguageManager.Culture = CultureInfo.InvariantCulture;
            });
        }
    }
}
