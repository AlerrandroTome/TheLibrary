using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Application.Interfaces;
using TheLibrary.Application.Services;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManagerBookCategoryService, ManagerBookCategoryService>();
            services.AddScoped<IManagerLoginService, ManagerLoginService>();
            services.AddScoped<IManagerUserService, ManagerUserService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
