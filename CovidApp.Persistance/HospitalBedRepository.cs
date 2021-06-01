using AutoMapper;
using CovidApp.Model;
using CovidApp.Persistance.API;
using CovidApp.Persistance.CovidAppContext;
using CovidApp.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance
{
    public class HospitalBedRepository : IHospitalBedRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<HospitalBedRepository> logger;
        readonly IMapper mapper;

        public HospitalBedRepository(CovidAppDbContext dbContext, ILogger<HospitalBedRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task AddOrUpdateHospitalBed(IList<AmritVahiniDataModel> entries, IList<LocationModel> locations)
        {
            try
            {
                
                 var hospitalBeds = await dbContext.HospitalBeds.Where(x => x.CityId == 1).ToListAsync();
                //Combine both data to get Bed Availablity Data
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
                    }
                    else
                    {
                        var hospitalBedEntity = new HospitalBed
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
                        await dbContext.HospitalBeds.AddAsync(hospitalBedEntity);
                    }
                }
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Added Hospital Beds at " + DateTime.UtcNow);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Hospital Beds", ex);
            }
        }

        public async Task<IList<HospitalBedModel>> GetHospitalBeds(int cityId)
        {
            try
            {
                var hospitalBeds = await dbContext.HospitalBeds
                                            .Where(x => x.CityId == cityId)
                                            .Include(x => x.Location)
                                            .OrderByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.Votes)
                                            .ToListAsync();

                return mapper.Map<List<HospitalBed>, List<HospitalBedModel>>(hospitalBeds);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Hospital Beds", ex);
                return null;
            }
        }
    }
}
