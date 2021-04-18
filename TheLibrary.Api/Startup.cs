using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheLibrary.Api.Configurations;
using TheLibrary.Infrastructure.Configurations;
using TheLibrary.Infrastructure.Data.Configurations;

namespace TheLibrary.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStrings = new ConnStringSettings();
            Configuration.Bind(key: nameof(connectionStrings), connectionStrings);

            var jwtSettings = new JwtSettings();
            Configuration.Bind(key: nameof(jwtSettings), jwtSettings);

            services.AddJsonSetup();

            services.AddRouting();

            services.AddOdataSetup();

            services.AddAppSettingsSetup(Configuration);

            services.AddDependencyInjectionSetup();

            services.AddDatabaseSetup(connectionStrings.ConnString);

            services.AddAutoMapper(typeof(Infrastructure.AutoMapper.AutoMapper));

            services.AddMiddlewareSetup();

            services.AddFluentValidationSetup();

            services.AddControllers();

            services.AddAuthenticationSetup(jwtSettings.Secret, jwtSettings);

            services.AddSwaggerSetup();

            services.AddHttpClient();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddCorsSetup();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseOdataSetup();

            app.UseSwaggerSetup();
        }
    }
}
