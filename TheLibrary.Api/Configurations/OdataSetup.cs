using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
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
            services.AddOData(opt =>
            {
                opt.AddModel("odata", GetEdmModel());
                opt.Expand().Filter().SkipToken().SetMaxTop(100).Count().OrderBy().Select();
                opt.SetTimeZoneInfo(TimeZoneInfo.FindSystemTimeZoneById("SA Eastern Standard Time"));
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
