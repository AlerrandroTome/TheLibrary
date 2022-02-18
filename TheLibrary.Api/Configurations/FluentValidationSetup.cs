using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using TheLibrary.Api.Validators.Login;

namespace TheLibrary.Api.Configurations
{
    public static class FluentValidationSetup
    {
        public static void AddFluentValidationSetup(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
                options.ValidatorOptions.LanguageManager.Culture = CultureInfo.CreateSpecificCulture("en-us");
            });
        }
    }
}
