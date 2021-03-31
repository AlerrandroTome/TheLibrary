using Microsoft.AspNetCore.Builder;

namespace TheLibrary.Infrastructure.Data.Configurations
{
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IApplicationBuilder app)
        {
            app.UseCors(options => options
                        .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
            );
        }
    }
}
