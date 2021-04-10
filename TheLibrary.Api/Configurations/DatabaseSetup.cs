using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Infrastructure.Data.Context;

namespace TheLibrary.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options => 
                options.UseSqlServer(configuration.GetSection("ConnectionStrings").GetSection("ConnString").Value)
            );
        }
    }
}
