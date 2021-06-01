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
                using (var scope = services.CreateScope())
                {
                    var masterRepository =
                        scope.ServiceProvider
                            .GetRequiredService<IMasterRepository>();

                    locations = await masterRepository.GetLocations(1, (int)LocationType.Hospitals);
                }
                
                //Store data to DB
                using (var scope = services.CreateScope())
                {
                    var hospitalBedRepository =
                        scope.ServiceProvider
                            .GetRequiredService<IHospitalBedRepository>();

                    await hospitalBedRepository.AddOrUpdateHospitalBed(entries, locations);
                }
                //Wait 3 hours to run again
                await Task.Delay(TimeSpan.FromHours(3), cancellationToken);
            }
        }
    }
}
