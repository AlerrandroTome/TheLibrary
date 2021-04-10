using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TheLibrary.Api.Configurations;
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
            services.AddJsonSetup();

            services.AddRouting();

            services.AddOdataSetup();

            services.AddAppSettingsSetup(Configuration);

            services.AddDependencyInjectionSetup();

            services.AddDatabaseSetup(Configuration);

            services.AddAutoMapper(typeof(Infrastructure.AutoMapper.AutoMapper));

            services.AddMiddlewareSetup();

            services.AddFluentValidationSetup();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "The Library API", 
                    Version = "v1", 
                    Description = "Documentation of TheLibraryApi." 
                });
            });

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

            app.UseAuthorization();

            app.UseOdataSetup();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheLibraryApi v1"));
        }
    }
}
