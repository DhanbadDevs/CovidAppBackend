using CovidApp.Common.Enums;
using CovidApp.Integration.API.AmritVahini;
using CovidApp.Model;
using CovidApp.Persistance.API;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CovidApp.Core.BackgroundWorkers
{
    public interface IAVScrapperBackgroundWorker : IHostedService
    {

    }
    public class AVScrapperBackgroundWorker : BackgroundWorkerBase, IAVScrapperBackgroundWorker
    {
        readonly ILogger<AVScrapperBackgroundWorker> logger;
        readonly IAmritVahiniGateway amritVahiniGateway;
        readonly IServiceProvider services;

        public AVScrapperBackgroundWorker(ILogger<AVScrapperBackgroundWorker> logger, IServiceProvider services, IAmritVahiniGateway amritVahiniGateway) : base(logger)
        {
            this.logger = logger;
            this.services = services;
            this.amritVahiniGateway = amritVahiniGateway;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Fetching Data from AV...");
                Debug.WriteLine("Fetching Data from AV...");
                //Get Scrapped Data
                var entries = amritVahiniGateway.GetBedData();
                //Get Locations from DB
                IList<LocationModel> locations;
                IList<HospitalBedModel> hospitalBeds;
                using (var scope = services.CreateScope())
                {
                    var masterRepository =
                        scope.ServiceProvider
                            .GetRequiredService<IMasterRepository>();

                    locations = await masterRepository.GetLocations(1, (int)LocationType.Hospitals);
                }
                using (var scope = services.CreateScope())
                {
                    var hospitalBedRepository =
                        scope.ServiceProvider
                            .GetRequiredService<IHospitalBedRepository>();

                    hospitalBeds = await hospitalBedRepository.GetHospitalBeds(1);
                }
                //Combine both data to get Bed Availablity Data
                var hospitalBedModels = new List<HospitalBedModel>();
                foreach (var entry in entries)
                {
                    var locationData = locations.Where(x => x.LocationName == entry.HospitalName).FirstOrDefault();
                    if (locationData == null)
                        continue;
                    var hospitalBed = hospitalBeds.Where(x => x.LocationId == locationData.Id).FirstOrDefault();
                    if (hospitalBed != null)
                    {
                        hospitalBed.WithoutOxygen = entry.WithoutOxygen;
                        hospitalBed.WithOxygen = entry.WithOxygen;
                        hospitalBed.IcuWithoutVentilator = entry.IcuWithoutVentilator;
                        hospitalBed.IcuWithVentilator = entry.IcuWithVentilator;
                        hospitalBed.UpdatedOn = DateTime.UtcNow;

                        hospitalBedModels.Add(hospitalBed);
                    }
                    else
                    {
                        var hospitalBedModel = new HospitalBedModel
                        {
                            WithoutOxygen = entry.WithoutOxygen,
                            WithOxygen = entry.WithOxygen,
                            IcuWithoutVentilator = entry.IcuWithoutVentilator,
                            IcuWithVentilator = entry.IcuWithVentilator,
                            CityId = locationData.CityId,
                            Charges = "Not Available",
                            LocationId = locationData.Id,
                            IsVerified = true,
                            UpdatedOn = DateTime.UtcNow,
                            Phone = locationData.Phone,
                            CreatedOn = DateTime.UtcNow
                        };
                        hospitalBedModels.Add(hospitalBedModel);
                    }
                }
                //Store data to DB
                using (var scope = services.CreateScope())
                {
                    var hospitalBedRepository =
                        scope.ServiceProvider
                            .GetRequiredService<IHospitalBedRepository>();

                    await hospitalBedRepository.AddOrUpdateHospitalBed(hospitalBedModels);
                }
                //Wait 3 hours to run again
                await Task.Delay(TimeSpan.FromHours(3), cancellationToken);
            }
        }
    }
}
