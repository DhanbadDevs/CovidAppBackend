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

        public async Task<HospitalBedModel> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel)
        {
            try
            {
                var hospitalBed = await dbContext.HospitalBeds
                                                 .Where(x => x.CityId == hospitalBedModel.CityId
                                                            && x.LocationId == hospitalBedModel.LocationId
                                                            && x.BedType == hospitalBedModel.BedType)
                                                 .FirstOrDefaultAsync();
                if (hospitalBed != null)
                {
                    hospitalBed.BedCount = hospitalBedModel.BedCount;
                    hospitalBed.Charges = hospitalBedModel.Charges;
                    hospitalBed.IsVerified = hospitalBedModel.IsVerified;
                    hospitalBed.Notes = hospitalBedModel.Notes;
                    hospitalBed.Phone = hospitalBedModel.Phone;
                    if (hospitalBed.BedCount != hospitalBedModel.BedCount)
                        hospitalBed.Votes = 0;
                    hospitalBed.UpdatedOn = DateTime.UtcNow;
                } 
                else
                {
                    hospitalBed = mapper.Map<HospitalBedModel, HospitalBed>(hospitalBedModel);
                    await dbContext.HospitalBeds.AddAsync(hospitalBed);
                }

                await dbContext.SaveChangesAsync();

                return mapper.Map<HospitalBed, HospitalBedModel>(hospitalBed);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Hospital Bed", ex);
                return null;
            }
        }

        public async Task<IList<HospitalBedModel>> GetHospitalBeds(string bedType)
        {
            try
            {
                var hospitalBeds = await dbContext.HospitalBeds
                                            .Include(x => x.Location)
                                            .OrderByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.BedCount)
                                            .ThenByDescending(x => x.Votes)
                                            .Where(x => x.BedType == bedType)
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
