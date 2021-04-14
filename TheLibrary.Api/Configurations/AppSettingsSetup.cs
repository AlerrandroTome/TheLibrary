using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Infrastructure.Configurations;

namespace TheLibrary.Api.Configurations
{
    public static class AppSettingsSetup
    {
        public static void AddAppSettingsSetup(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings").GetSection("ConnString"));
            service.Configure<JwtSettings>(configuration.GetSection("JwtSettings").GetSection("Secret"));
        }
    }
}