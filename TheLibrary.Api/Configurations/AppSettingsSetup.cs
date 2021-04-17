using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TheLibrary.Infrastructure.Configurations;

namespace TheLibrary.Api.Configurations
{
    public static class AppSettingsSetup
    {
        public static void AddAppSettingsSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnStringSettings>(configuration.GetSection(nameof(ConnStringSettings)));
            services.AddSingleton<IConnStringSettings>(x => x.GetRequiredService<IOptions<ConnStringSettings>>().Value);

            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
            services.AddSingleton<IJwtSettings>(x => x.GetRequiredService<IOptions<JwtSettings>>().Value);
        }
    }
}