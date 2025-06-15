using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Extensions.Identity;
using ServiceLayer.FluentValidation.WebApplication.HomePageValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            services.LoadIdentityExtensions();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Service dagi interface va classni har birini yozib chiqmay generic ko'rinishida yozamiz
            //services.AddScoped<IAboutService, AboutService>();
            var takror = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service"));
            foreach (var serviceType in takror)
            {
                var iServiceType = serviceType.GetInterfaces().FirstOrDefault(x => x.Name == $"I{serviceType.Name}");
                if (iServiceType != null)
                {
                    services.AddScoped(iServiceType, serviceType);
                }
            }

            services.AddFluentValidationAutoValidation(opt=>
            {
                opt.DisableDataAnnotationsValidation = true;
            });
            services.AddValidatorsFromAssemblyContaining<HomePageAddValidation>();

            return services;
        }
    }
}
