using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Core.Delegates;
using CovidApp.Core.Services;
using CovidApp.Persistance;
using CovidApp.Persistance.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp.Extensions
{
    public static class MvcExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new ResponseCacheAttribute()
                    {
                        NoStore = true,
                        Location = ResponseCacheLocation.None
                    });
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        /// <summary>
        /// Register the classes
        /// </summary>
        /// <param name="services"></param>
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IVaccineRepository, VaccineRepository>();
            services.AddScoped<IVaccineService, VaccineService>();
            services.AddScoped<IVaccineDelegate, VaccineDelegate>();
            services.AddScoped<IAmbulanceRepository, AmbulanceRepository>();
            services.AddScoped<IAmbulanceService, AmbulanceService>();
            services.AddScoped<IAmbulanceDelegate, AmbulanceDelegate>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IMasterDelegate, MasterDelegate>();
        }
    }
}
