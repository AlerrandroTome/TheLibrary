using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TheLibrary.Api.Configurations;
using TheLibrary.Core.Shared;
using TheLibrary.Infrastructure.Data.Configurations;

namespace TheLibrary.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string connString;

        public Startup(IConfiguration configuration, IOptions<ConnectionsString> options)
        {
            Configuration = configuration;
            connString = options.Value.ConnString;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonSetup();

            services.AddOdataSetup();

            services.AddAppSettingsSetup(Configuration);

            services.AddDependencyInjectionSetup();

            services.AddDatabaseSetup(connString);

            services.AddAutoMapper(new [] { Assembly.GetExecutingAssembly() });

            services.AddMiddlewareSetup();

            services.AddFluentValidationSetup();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheLibrary.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddCorsSetup();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("api/v1/swagger.json", "TheLibrary.Api"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
