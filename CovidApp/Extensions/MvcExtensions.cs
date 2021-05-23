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
            services.AddScoped<IVaccinationCentreRepository, VaccinationCentreRepository>();
            services.AddScoped<IVaccinationCentreService, VaccinationCentreService>();
            services.AddScoped<IVaccinationCentreDelegate, VaccinationCentreDelegate>();
            services.AddScoped<IAmbulanceRepository, AmbulanceRepository>();
            services.AddScoped<IAmbulanceService, AmbulanceService>();
            services.AddScoped<IAmbulanceDelegate, AmbulanceDelegate>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IMasterDelegate, MasterDelegate>();
            services.AddScoped<IHospitalBedRepository, HospitalBedRepository>();
            services.AddScoped<IHospitalBedService, HospitalBedService>();
            services.AddScoped<IHospitalBedDelegate, HospitalBedDelegate>();
            services.AddScoped<IMedicineEquipmentRepository, MedicineEquipmentRepository>();
            services.AddScoped<IMedicineEquipmentService, MedicineEquipmentService>();
            services.AddScoped<IMedicineEquipmentDelegate, MedicineEquipmentDelegate>();
            services.AddScoped<IOxygenRepository, OxygenRepository>();
            services.AddScoped<IOxygenService, OxygenService>();
            services.AddScoped<IOxygenDelegate, OxygenDelegate>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorDelegate, DoctorDelegate>();
        }
    }
}