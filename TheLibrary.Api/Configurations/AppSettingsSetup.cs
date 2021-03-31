using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Core.Shared;

namespace TheLibrary.Api.Configurations
{
    public static class AppSettingsSetup
    {
        public static void AddAppSettingsSetup(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ConnectionsString>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
