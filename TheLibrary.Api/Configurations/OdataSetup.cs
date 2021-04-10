using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using System;
using System.Linq;
using System.Reflection;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Api.Configurations
{
    public static class OdataSetup
    {
        public static void AddOdataSetup(this IServiceCollection services)
        {
            services.AddOData();

            services.AddMvcCore(options =>
            {
                options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0).ToList().ForEach(outputFormatter =>
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                });

                options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0).ToList().ForEach(inputFormatter =>
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                });
            });
        }

        public static void UseOdataSetup(this IApplicationBuilder app)
        {
            app.UseEndpoints(opt =>
            {
                opt.EnableDependencyInjection();
                opt.MapODataRoute("odata", "odata", GetEdmModel());
                opt.Expand().Filter().SkipToken().Count().OrderBy().Select().MaxTop(100);
                opt.SetTimeZoneInfo(TimeZoneInfo.FindSystemTimeZoneById("SA Eastern Standard Time"));
                //opt.MapControllers();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();

            var entities = AppDomain.CurrentDomain.GetAssemblies()
                                                  .SelectMany(w => w.GetTypes())
                                                  .Where(w => 
                                                      w.FullName.Contains("TheLibrary.Domain.Entities") 
                                                      && w.GetInterfaces().Any(w => w.Name.Equals(nameof(IODataEntity))) 
                                                      && !w.IsInterface 
                                                      && !w.IsAbstract
                                                  )
                                                  .ToList();

            entities.ForEach(entity =>
            {
                MethodInfo mi = builder.GetType().GetMethod("EntitySet");
                MethodInfo miConstructed = mi.MakeGenericMethod(entity);
                miConstructed.Invoke(builder, new[] { entity.Name });
            });

            return builder.GetEdmModel();
        }
    }
}
