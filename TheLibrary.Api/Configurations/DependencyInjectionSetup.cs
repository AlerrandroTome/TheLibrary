using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Application.Services;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManageBookCategoryService, ManageBookCategoryService>();
            services.AddScoped<IManageAuthorService, ManageAuthorService>();
            services.AddScoped<IManageBookService, ManageBookService>();
            services.AddScoped<IManageLoginService, ManageLoginService>();
            services.AddScoped<IManageUserService, ManageUserService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
